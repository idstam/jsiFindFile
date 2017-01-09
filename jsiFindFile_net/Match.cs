using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jsiFindFile
{
    public class Match
    {
        public string FileName { get; private set; }

        public string FilePath => Path.GetDirectoryName(FullPath);

        public List<MatchLine> MatchLines{get;}
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