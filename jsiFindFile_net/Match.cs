using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jsiGrepWinForm
{
    public class Match
    {
        public string FileName { get; set; }
    	public string FilePath { get; set; }
    	public List<MatchLine> MatchLines{get;set;}
		public string Needle { get; set; }
        private string _fullPath;

        public Match(string fullPath, string needle)
        {
            MatchLines = new List<MatchLine>();
            Needle = needle;
            _fullPath = fullPath;
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