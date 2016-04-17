using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jint.Native;
using Jint.Runtime;

namespace JintDebugger
{
    public class StandardConsoleOutput : IFirebugConsoleOutput
    {
        private static readonly Regex NewlineRe = new Regex("\r?\n", RegexOptions.Compiled);

        private int _indentation;
        private int _indent;

        public int Indentation
        {
            get { return _indentation; }
            set { _indentation = Math.Max(value, 0); }
        }

        public int Indent
        {
            get { return _indent; }
            set { _indent = Math.Max(value, 0); }
        }

        public StandardConsoleOutput()
        {
            Indent = 2;
        }

        public void Log(FirebugConsoleMessageStyle style, string value)
        {
            var color = Console.ForegroundColor;
            switch (style)
            {
                case FirebugConsoleMessageStyle.Information:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case FirebugConsoleMessageStyle.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case FirebugConsoleMessageStyle.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(NewlineRe.Replace(value, p => Environment.NewLine));
            Console.ForegroundColor = color;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void StartGroup(string title, bool initiallyCollapsed)
        {
            Log(FirebugConsoleMessageStyle.Regular, title);
            Indentation += Indent;
        }

        public void EndGroup()
        {
            Indentation -= Indent;
        }
    }
}
