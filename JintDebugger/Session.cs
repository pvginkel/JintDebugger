using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jint;
using Jint.Parser;
using Jint.Runtime.Debugger;

namespace JintDebugger
{
    internal class Session : IDisposable
    {
        private readonly IJintSessionCallback _callback;
        private bool _disposed;
        private Thread _thread;
        private string _baseDirectory;
        private readonly object _syncRoot = new object();
        private bool _breakOnNextStatement;

        public Engine Engine { get; private set; }

        public Session(IJintSessionCallback callback)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            _callback = callback;
        }

        public event JintDebuggerStoppedEventHandler Stopped;

        protected virtual void OnStopped(JintDebuggerStoppedEventArgs e)
        {
            Stopped?.Invoke(this, e);
        }

        public event SourceLoadedEventHandler SourceLoaded;

        protected virtual void OnSourceLoaded(SourceLoadedEventArgs e)
        {
            SourceLoaded?.Invoke(this, e);
        }

        public void Run(string baseDirectory, string script, string fileName, bool debug, Action<Engine> setup)
        {
            _baseDirectory = baseDirectory;

            _thread = new Thread(() => ThreadProc(script, fileName, debug, setup));
            _thread.Start();
        }

        private void ThreadProc(string script, string fileName, bool debug, Action<Engine> setup)
        {
            Engine = new Engine(p => p
                .DebugMode(debug)
                .AllowClr()
            );

            Engine.Break += engine_Break;
            Engine.Step += engine_Step;
            Engine.SourceLoaded += (s, e) => OnSourceLoaded(e);

            Engine.SetValue("require", new Func<string, object>(RequireFunction));

            setup?.Invoke(Engine);

            Exception exception = null;

            try
            {
                Engine.Execute(script, new ParserOptions { Source = fileName });

                Engine = null;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                OnStopped(new JintDebuggerStoppedEventArgs(exception));
            }
        }

        private object RequireFunction(string fileName)
        {
            if (!Path.IsPathRooted(fileName))
                fileName = Path.Combine(_baseDirectory, fileName);

            return Engine.Execute(File.ReadAllText(fileName), new ParserOptions { Source = fileName });
        }

        public bool BreakOnNextStatement
        {
            get { return _breakOnNextStatement; }
            set
            {
                if (_breakOnNextStatement != value)
                {
                    _breakOnNextStatement = value;
                    OnBreakOnNextStatementChanged(EventArgs.Empty);
                }
            }
        }

        internal event EventHandler BreakOnNextStatementChanged;

        private void OnBreakOnNextStatementChanged(EventArgs e)
        {
            BreakOnNextStatementChanged?.Invoke(null, e);
        }

        StepMode engine_Break(object sender, DebugInformation e)
        {
            return ProcessStep(sender, e, BreakType.Break);
        }

        StepMode engine_Step(object sender, DebugInformation e)
        {
            return ProcessStep(sender, e, BreakType.Step);
        }

        private StepMode ProcessStep(object sender, DebugInformation e, BreakType breakType)
        {
            lock (_syncRoot)
            {
                if (breakType == BreakType.Step && !BreakOnNextStatement)
                    return StepMode.None;

                BreakOnNextStatement = false;

                using (var continuation = _callback.ProcessStep((Engine)sender, e, breakType))
                {
                    return continuation.Wait();
                }
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_thread != null)
                {
                    _thread.Abort();
                    _thread = null;
                }

                _disposed = true;
            }
        }
    }
}
