using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;

namespace JintDebugger
{
    public class EngineCreatedEventArgs : EventArgs
    {
        public Engine Engine { get; }

        public EngineCreatedEventArgs(Engine engine)
        {
            if (engine == null)
                throw new ArgumentNullException(nameof(engine));

            Engine = engine;
        }
    }

    public delegate void EngineCreatedEventHandler(object sender, EngineCreatedEventArgs e);
}
