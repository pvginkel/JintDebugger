using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint.Runtime.Debugger;

namespace JintDebugger
{
    public class EditorBreakPoint
    {
        public int Line { get; }
        public int Column { get; }
        public BreakPoint BreakPoint { get; set; }

        public EditorBreakPoint(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }
}
