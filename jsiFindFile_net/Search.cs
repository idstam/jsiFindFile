using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jsiFindFile
{
    public class SearchManager
    {
        private bool _stop;
        private readonly string[] _includeFilters;
        private readonly string[] _excludeFilters;
        private readonly string _needle;
        private readonly bool _searchSubFolders;
        private readonly bool _includeFileNames;

        public SearchManager(string[] includeFilters, string[] excludeFilters, string needle, bool searchSubFolders, bool includeFileNames)
        {
            _includeFilters = includeFilters.Where(f => f != "").ToArray();
            _excludeFilters = null;
            _excludeFilters = excludeFilters.Where(f => f != "").ToArray();
            _searchSubFolders = searchSubFolders;
            _includeFileNames = includeFileNames;
            _needle = needle;
            _stop = false;
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

            var folderContent = GetFolderContent(rootFolder);

			matches.AddRange(SearchFiles(folderContent.Item1.ToList()));

            if (_searchSubFolders)
            {
                foreach (var folder in folderContent.Item2)
                {
                    if(ExcludePathContaining(folder)) continue;

                    if (_stop) return matches;
                    Search(folder, matches);
                }
            }

            return matches;
        }

        private List<Match> Search(List<string> files)
        {
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

                if (_stop) return ret;
            }
            //);

            return ret;
        }

        private Tuple<string[], string[]> GetFolderContent(string rootFolder)
        {
            try
            {
                var files = Directory.GetFiles(rootFolder);
                var folders = Directory.GetDirectories(rootFolder);
                return new Tuple<string[], string[]>(files, folders);
            }
            catch (Exception)
            {
                return new Tuple<string[], string[]>(new string[0], new string[0] );
            }
        }

        private bool IncludeFile(string filename)
        {
            if (_includeFilters == null || _includeFilters.Length == 0) return true;

            foreach (var filter in _includeFilters)
            {
                if (filename.ToUpperInvariant().Like(filter)) return true;
            }
            return false;
        }

        private bool ExcludePathContaining(string filename)
        {
            if (_excludeFilters == null || _excludeFilters.Length == 0) return false;

            foreach (var filter in _excludeFilters)
            {
                if (filename.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private Match SearchFile(string fileName)
        {
            var match = new Match(fileName, _needle);

            var lineNumber = 0;
            int index = fileName.IndexOf(_needle, StringComparison.InvariantCultureIgnoreCase);
            if (index >= 0)
            {
                match.MatchLines.Add(new MatchLine()
                {
                    Line = "[Match on filename]",
                    LineNumber = lineNumber,
                    Position = 0
                });
            }
            try
            {
                foreach (var line in File.ReadLines(fileName))
                {
                    lineNumber++;
                    //var upperLine = line.ToUpperInvariant();
                    //if (upperLine.Contains(needle))
                    index = line.IndexOf(_needle, StringComparison.InvariantCultureIgnoreCase);
                    if (index >= 0 )
                    {
                        match.MatchLines.Add(new MatchLine()
                        {
                    	    Line = line,
                            LineNumber = lineNumber,
                            Position = index
                        });                    
                    }
                    if (_stop) break;
                }
            }
            catch (Exception ex)
            {
                match.MatchLines.Add(new MatchLine()
                {
                    Line = "[ERROR] " + ex.Message,
                    LineNumber = 0,
                    Position = 0
                });
            }
            if (match.MatchLines.Any())
            {
                OnFoundMatch(new MatchEventArgs {Match = match});
                return match;
            }
            else
            {
                OnFoundMatch(new MatchEventArgs { Match = null });
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

        public void Stop()
        {
            _stop = true;
        }
    }

    public class SearchingFolderEventArgs : EventArgs
    {
        public string Folder { get; set; }
    }
}