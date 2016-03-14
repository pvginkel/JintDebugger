using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Jint.Runtime.Debugger;

namespace JintDebugger
{
    internal class Continuation : IDisposable
    {
        private bool _disposed;
        private ManualResetEvent _event = new ManualResetEvent(false);
        private StepMode _stepMode;

        public void Signal(StepMode stepMode)
        {
            _stepMode = stepMode;
            _event.Set();
        }

        public StepMode Wait()
        {
            _event.WaitOne();
            return _stepMode;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_event != null)
                {
                    _event.Close();
                    _event = null;
                }

                _disposed = true;
            }
        }
    }
}
