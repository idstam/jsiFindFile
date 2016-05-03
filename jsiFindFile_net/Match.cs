using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jsiGrepWinForm
{
    public class Match
    {
        public string FileName { get; set; }

        public string FilePath
        {
            get { return Path.GetDirectoryName(FullPath); }
        }

        public List<MatchLine> MatchLines{get;set;}
		public string Needle { get; set; }

        public string FullPath { get; set; }

        public Match(string fullPath, string needle)
        {
            MatchLines = new List<MatchLine>();
            Needle = needle;
            FullPath = fullPath;
            FileName = Path.GetFileName(FullPath);
        }

        public string ToToolTipString()
        {
            return MatchLines.Aggregate("", (current, line) => current + ($"{line.LineNumber}.{line.Position} {line.Line}" + Environment.NewLine));
        }
    }


    public class MatchLine
    {
        public string Line { get; set; }
        public int LineNumber { get; set; }
    	public int Position { get; set; }

    }

    public class MatchEventArgs : EventArgs
    {
        public Match Match;
    }
}