using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace jsiFindFile
{
    public class Settings
    {
        public string LastIncludeFilter {
            get{return _data.IncludeFilterSet.LastOrDefault();}
            set { _data.IncludeFilterSet.Add(value); } }

        public string[] IncludeFilters => _data.IncludeFilterSet.Reverse().ToArray();

        public string ExcludeFilter
        {
            get { return _data.ExcludeFilterSet.LastOrDefault(); }
            set { _data.ExcludeFilterSet.Add(value); }
        }

        public string LastSearchRoot
        {
            get { return _data.SearchRootSet.LastOrDefault(); }
            set { _data.SearchRootSet.Add(value); }
        }
        public string[] SearchRoots => _data.SearchRootSet.Reverse().ToArray();

        public string LastNeedle
        {
            get { return _data.NeedleSet.LastOrDefault(); }
            set { _data.NeedleSet.Add(value); }
        }
        public string[] Needles => _data.NeedleSet.Reverse().ToArray();


        private string _fileName;
        private SettingsData _data;

        public Settings()
        {
            Load();
        }

        private void Load()
        {
            string appname = "jsifind";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appname);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            _fileName = Path.Combine(path, appname + ".settings");

            if (File.Exists(_fileName))
            {
                var fs = File.OpenRead(_fileName);
                var ser = new DataContractJsonSerializer(typeof(SettingsData));
                _data = (SettingsData) ser.ReadObject(fs);
                fs.Dispose();
            }
            else
            {
                _data = new SettingsData();
            }
        }

        public void ClearNeedleHistory()
        {
            _data.NeedleSet = new HashSet<string>();
            Save();
        }

        public void ClearIncludeHistory()
        {
            _data.IncludeFilterSet = new HashSet<string>();
            Save();
        }
        public void Save()
        {
            var tempFile = _fileName + ".tmp";
            if(File.Exists(tempFile)) File.Delete(tempFile);

            var fs = File.OpenWrite(tempFile);
            var ser = new DataContractJsonSerializer(typeof(SettingsData));
            ser.WriteObject(fs,_data);
            fs.Dispose();
            if(File.Exists(_fileName + ".old")) File.Delete(_fileName + ".old");
            if (File.Exists(_fileName)) File.Move(_fileName, _fileName + ".old");
            if (File.Exists(tempFile))  File.Move(tempFile, _fileName);

        }
    }
    [DataContract]
    public class SettingsData
    {
        public SettingsData()
        {
            IncludeFilterSet = new HashSet<string>();
            ExcludeFilterSet = new HashSet<string>();
            SearchRootSet = new HashSet<string>();
            NeedleSet = new HashSet<string>();
        }
        [DataMember]
        public HashSet<string> IncludeFilterSet { get; set; }
        [DataMember]
        public HashSet<string> ExcludeFilterSet { get; set; }
        [DataMember]
        public HashSet<string> SearchRootSet { get; set; }
        [DataMember]
        public HashSet<string> NeedleSet { get; set; }
    }
}
