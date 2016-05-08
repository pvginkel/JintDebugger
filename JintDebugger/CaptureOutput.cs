using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JintDebugger
{
    public class CaptureOutput : IFirebugConsoleOutput
    {
        private static readonly Regex NewlineRe = new Regex("\r?\n", RegexOptions.Compiled);

        private int _indentation;
        private int _indent;
        private readonly StringBuilder _sb = new StringBuilder();

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

        public CaptureOutput()
        {
            Indent = 2;
        }

        public void Log(FirebugConsoleMessageStyle style, string value)
        {
            string indent = new string(' ', Indentation);

            foreach (string line in NewlineRe.Split(value))
            {
                _sb.AppendLine(indent + line);
            }
        }

        public void Clear()
        {
            _sb.Clear();
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

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
