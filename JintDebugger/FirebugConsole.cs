using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jint;
using Jint.Native;
using Jint.Native.Object;
using Jint.Runtime;
using Jint.Runtime.Interop;

namespace JintDebugger
{
    public class FirebugConsole : ObjectInstance
    {
        private static readonly Regex PatternRe = new Regex("%[sdif%oO]", RegexOptions.Compiled);

        private readonly Dictionary<string, Stopwatch> _timers = new Dictionary<string, Stopwatch>();

        public IFirebugConsoleOutput Output { get; set; }

        public FirebugConsole(Engine engine)
            : this(engine, null)
        {
        }

        public FirebugConsole(Engine engine, IFirebugConsoleOutput output)
            : base(engine)
        {
            Output = output ?? new StandardConsoleOutput();
            Configure();
        }

        public static FirebugConsole CreateFirebugConsole(Engine engine)
        {
            return CreateFirebugConsole(engine, null);
        }

        public static FirebugConsole CreateFirebugConsole(Engine engine, IFirebugConsoleOutput output)
        {
            return new FirebugConsole(engine, output) { Prototype = engine.Object.PrototypeObject };
        }

        private void Configure()
        {
            FastAddProperty("log", new ClrFunctionInstance(Engine, Log, 0), true, false, true);
            FastAddProperty("debug", new ClrFunctionInstance(Engine, Debug, 0), true, false, true);
            FastAddProperty("info", new ClrFunctionInstance(Engine, Info, 0), true, false, true);
            FastAddProperty("warn", new ClrFunctionInstance(Engine, Warn, 0), true, false, true);
            FastAddProperty("error", new ClrFunctionInstance(Engine, Error, 0), true, false, true);
            FastAddProperty("assert", new ClrFunctionInstance(Engine, Assert, 1), true, false, true);
            FastAddProperty("clear", new ClrFunctionInstance(Engine, Clear, 0), true, false, true);
            FastAddProperty("group", new ClrFunctionInstance(Engine, Group, 0), true, false, true);
            FastAddProperty("groupCollapsed", new ClrFunctionInstance(Engine, GroupCollapsed, 0), true, false, true);
            FastAddProperty("groupEnd", new ClrFunctionInstance(Engine, GroupEnd, 0), true, false, true);
            FastAddProperty("time", new ClrFunctionInstance(Engine, Time, 1), true, false, true);
            FastAddProperty("timeEnd", new ClrFunctionInstance(Engine, TimeEnd, 1), true, false, true);
        }

        private JsValue Log(FirebugConsoleMessageStyle style, JsValue thisObject, JsValue[] arguments)
        {
            Output.Log(style, Format(arguments));

            return JsValue.Undefined;
        }

        private JsValue Log(JsValue thisObject, JsValue[] arguments)
        {
            return Log(FirebugConsoleMessageStyle.Regular, thisObject, arguments);
        }

        private JsValue Debug(JsValue thisObject, JsValue[] arguments)
        {
            return Log(FirebugConsoleMessageStyle.Regular, thisObject, arguments);
        }

        private JsValue Info(JsValue thisObject, JsValue[] arguments)
        {
            return Log(FirebugConsoleMessageStyle.Information, thisObject, arguments);
        }

        private JsValue Warn(JsValue thisObject, JsValue[] arguments)
        {
            return Log(FirebugConsoleMessageStyle.Warning, thisObject, arguments);
        }

        private JsValue Error(JsValue thisObject, JsValue[] arguments)
        {
            return Log(FirebugConsoleMessageStyle.Error, thisObject, arguments);
        }

        private JsValue Assert(JsValue thisObject, JsValue[] arguments)
        {
            if (!TypeConverter.ToBoolean(arguments.Length == 0 ? JsValue.Null : arguments[0]))
            {
                if (arguments.Length > 1)
                    arguments[0] = "Assertion failed:";
                else
                    arguments = new[] { new JsValue("Assertion failed") };
                Error(thisObject, arguments);
            }

            return JsValue.Undefined;
        }

        private JsValue Clear(JsValue thisObject, JsValue[] arguments)
        {
            Output.Clear();

            return JsValue.Undefined;
        }

        private JsValue Group(JsValue thisObject, JsValue[] arguments)
        {
            Output.StartGroup(Format(arguments), false);

            return JsValue.Undefined;
        }

        private JsValue GroupCollapsed(JsValue thisObject, JsValue[] arguments)
        {
            Output.StartGroup(Format(arguments), true);

            return JsValue.Undefined;
        }

        private JsValue GroupEnd(JsValue thisObject, JsValue[] arguments)
        {
            Output.EndGroup();

            return JsValue.Undefined;
        }

        private string Format(JsValue[] arguments)
        {
            if (arguments.Length == 0)
                return null;

            var sb = new StringBuilder();
            int offset = 0;

            if (arguments[0].IsString())
            {
                offset = 1;

                sb.Append(PatternRe.Replace(arguments[0].AsString(), p =>
                {
                    switch (p.Value[1])
                    {
                        case 's':
                            return arguments[offset++].ToString();
                        case 'd':
                        case 'i':
                            return ((int)arguments[offset++].AsNumber()).ToString();
                        case 'f':
                            return arguments[offset++].AsNumber().ToString();
                        case '%':
                            return "%";
                        case 'o':
                        case 'O':
                            return Engine.Json.Stringify(Engine.Json, new[] { arguments[offset++] }).ToString();
                        default:
                            throw new InvalidOperationException();
                    }
                }));
            }

            for (int i = offset; i < arguments.Length; i++)
            {
                if (i > 0)
                    sb.Append(' ');

                var value = arguments[i];

                if (value.IsObject())
                    sb.Append(Engine.Json.Stringify(Engine.Json, new[] { value }).AsString());
                else
                    sb.Append(TypeConverter.ToString(value));
            }

            return sb.ToString();
        }

        private JsValue Time(JsValue thisObject, JsValue[] arguments)
        {
            string name = arguments.Length == 0 ? String.Empty : arguments[0].ToString();
            if (!_timers.ContainsKey(name))
                _timers.Add(name, Stopwatch.StartNew());
            return JsValue.Undefined;
        }

        private JsValue TimeEnd(JsValue thisObject, JsValue[] arguments)
        {
            string name = arguments.Length == 0 ? String.Empty : arguments[0].ToString();
            Stopwatch stopwatch;
            if (_timers.TryGetValue(name, out stopwatch))
            {
                var sb = new StringBuilder();
                if (!String.IsNullOrEmpty(name))
                    sb.Append(name).Append(": ");
                sb.Append(stopwatch.Elapsed).Append("ms");

                Output.Log(FirebugConsoleMessageStyle.Regular, sb.ToString());

                _timers.Remove(name);
            }

            return JsValue.Undefined;
        }
    }
}
