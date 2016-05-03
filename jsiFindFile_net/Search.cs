using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace jsiGrepWinForm
{
    public class SearchManager
    {
        private string _rootFolder;
        private List<string> _originalFiles;
        private List<Match> _result;
        private bool _stop;
        private string[] _includeFilters;
        private string[] _excludeFilters;
        private string _needle;
        public SearchManager(string[] includeFilters, string[] excludeFilters, string needle)
        {
            _includeFilters = includeFilters?.Length > 0 ? includeFilters : null;
            _excludeFilters = excludeFilters?.Length > 0 ? excludeFilters : null;
            _needle = needle;
        }

        public List<Match> Search(object haystack)
        {
            if (haystack is string)
            {
                return Search((string) haystack);
            }
            else
            {
                return Search((List<string>) haystack);
            }

        }
        private List<Match> Search(string rootFolder, List<Match> matches = null)
        {
            if (matches == null) matches = new List<Match>();
            OnSearchingFolder(new SearchingFolderEventArgs {Folder = rootFolder});
            
            _rootFolder = rootFolder;
            var folderContent = GetFolderContent(rootFolder);

			matches.AddRange(SearchFiles(folderContent.Item1.ToList()));

            foreach (var folder in folderContent.Item2)
            {
                Search(folder, matches);
            }

            return matches;
        }

        private List<Match> Search(List<string> files)
        {
            _originalFiles = files;
            return SearchFiles(files);
        }

        private List<Match> SearchFiles(List<string> files)
        {
            var ret = new List<Match>();

            foreach (var f in files)
            //Parallel.ForEach(files, f =>
            {
                if (!IncludeFile(f)) continue;
                if (ExcludePathContaining(f)) continue;

                var match = SearchFile(f);
                if (match != null) ret.Add(match);
            }
            //);

            return ret;
        }

        private Tuple<string[], string[]> GetFolderContent(string rootFolder)
        {
            var files = Directory.GetFiles(rootFolder);
            var folders = Directory.GetDirectories(rootFolder);
            return new Tuple<string[], string[]>(files, folders);
        }

        private bool IncludeFile(string filename)
        {
            if (_includeFilters== null) return true;

            foreach (var filter in _includeFilters)
            {
                if (filename.ToUpperInvariant().Like(filter)) return true;
            }
            return false;
        }

        private bool ExcludePathContaining(string filename)
        {
            if (_excludeFilters == null) return false;

            foreach (var filter in _excludeFilters)
            {
                if (filename.ToUpperInvariant().Contains(filter))
                {
                    return true;
                }
            }
            return false;
        }

        private Match SearchFile(string fileName)
        {
            var needle = _needle.ToUpperInvariant();
            var match = new Match(fileName, _needle);

            var lineNumber = 0;
            foreach(var line in File.ReadLines(fileName))
            {
                lineNumber++;
                var upperLine = line.ToUpperInvariant();
                if (upperLine.Contains(needle))
                {
                    match.MatchLines.Add(new MatchLine()
                    {
                    	Line = line,
                        LineNumber = lineNumber,
                        Position = upperLine.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase)
                    });

                    
                }
            }
            if (match.MatchLines.Any())
            {
                OnFoundMatch(new MatchEventArgs {Match = match});
                return match;
            }
            else
            {
                return null;
            }
            
        }

        public event EventHandler FoundMatch ;
        private void OnFoundMatch(MatchEventArgs e)
        {
            var handler = FoundMatch;
            handler?.Invoke(this, e);
        }
        public event EventHandler SearchingFolder;
        private void OnSearchingFolder(SearchingFolderEventArgs e)
        {
            var handler = SearchingFolder;
            handler?.Invoke(this, e);
        }
    }

    public class SearchingFolderEventArgs : EventArgs
    {
        public string Folder { get; set; }
    }
}