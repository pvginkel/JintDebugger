using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;

namespace JintDebugger
{
    internal class JintDebuggerSteppedEventArgs
    {
        public Engine Engine { get; }
        public BreakType BreakType { get; }

        public JintDebuggerSteppedEventArgs(Engine engine, BreakType breakType)
        {
            Engine = engine;
            BreakType = breakType;
        }
    }

    internal delegate void JintDebuggerSteppedEventHandler(object sender, JintDebuggerSteppedEventArgs e);
}
