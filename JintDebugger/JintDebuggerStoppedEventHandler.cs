using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    internal class JintDebuggerStoppedEventArgs : EventArgs
    {
        public Exception Exception { get; }

        public JintDebuggerStoppedEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }

    internal delegate void JintDebuggerStoppedEventHandler(object sender, JintDebuggerStoppedEventArgs e);
}
