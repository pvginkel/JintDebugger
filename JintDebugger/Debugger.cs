using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using Jint.Runtime.Debugger;

namespace JintDebugger
{
    internal class Debugger : IDisposable, IJintSessionCallback
    {
        private bool _isRunning;
        private Session _session;
        private bool _disposed;
        private Continuation _continuation;

        public bool IsRunning
        {
            get { return _isRunning; }
            private set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnIsRunningChanged(EventArgs.Empty);
                }
            }
        }

        public DebugInformation DebugInformation { get; private set; }

        public Engine Engine => _session.Engine;

        public event EventHandler IsRunningChanged;

        protected virtual void OnIsRunningChanged(EventArgs e)
        {
            IsRunningChanged?.Invoke(this, e);
        }

        public event JintDebuggerStoppedEventHandler Stopped;

        protected virtual void OnStopped(JintDebuggerStoppedEventArgs e)
        {
            Stopped?.Invoke(this, e);
        }

        public event JintDebuggerSteppedEventHandler Stepped;

        protected virtual void OnStepped(JintDebuggerSteppedEventArgs e)
        {
            Stepped?.Invoke(this, e);
        }

        public event SourceLoadedEventHandler SourceLoaded;

        protected virtual void OnSourceLoaded(SourceLoadedEventArgs e)
        {
            SourceLoaded?.Invoke(this, e);
        }

        public Debugger()
        {
            _session = new Session(this);
            _session.Stopped += _session_Stopped;
            _session.SourceLoaded += (s, e) => OnSourceLoaded(e);
        }

        private void _session_Stopped(object sender, JintDebuggerStoppedEventArgs e)
        {
            IsRunning = false;

            OnStopped(e);
        }

        public void Run(string fileName, string script, Action<Engine> setup, bool startBreaked)
        {
            _session.BreakOnNextStatement = startBreaked;
            _session.Run(Path.GetDirectoryName(fileName), script, fileName, true, setup);

            IsRunning = true;
        }

        public void Break()
        {
            _session.BreakOnNextStatement = true;
        }

        public void Continue()
        {
            Continue(StepMode.None);
        }

        private void Continue(StepMode stepMode)
        {
            DebugInformation = null;
            IsRunning = true;

            var continuation = _continuation;
            _continuation = null;
            continuation.Signal(stepMode);
        }

        public void Step(StepMode stepMode)
        {
            _session.BreakOnNextStatement = true;

            Continue(stepMode);
        }

        Continuation IJintSessionCallback.ProcessStep(Engine engine, DebugInformation debugInformation, BreakType breakType)
        {
            IsRunning = false;

            Debug.Assert(_continuation == null);

            _continuation = new Continuation();

            DebugInformation = debugInformation;

            OnStepped(new JintDebuggerSteppedEventArgs(engine, breakType));

            return _continuation;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_session != null)
                {
                    _session.Dispose();
                    _session = null;
                }

                _disposed = true;
            }
        }
    }
}
