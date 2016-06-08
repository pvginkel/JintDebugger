using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    internal struct TextSpan
    {
        public int StartLine { get; }
        public int StartIndex { get; }
        public int EndLine { get; }
        public int EndIndex { get; }

        public TextSpan(int startLine, int startIndex, int endLine, int endIndex)
        {
            StartLine = startLine;
            StartIndex = startIndex;
            EndLine = endLine;
            EndIndex = endIndex;
        }
    }
}
