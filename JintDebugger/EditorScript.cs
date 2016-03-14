using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using Jint.Parser;

namespace JintDebugger
{
    public class EditorScript
    {
        public Engine Engine { get; }
        public Script Script { get; }

        public EditorScript(Engine engine, Script script)
        {
            if (engine == null)
                throw new ArgumentNullException(nameof(engine));
            if (script == null)
                throw new ArgumentNullException(nameof(script));

            Engine = engine;
            Script = script;
        }
    }
}
