using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Jint;
using Jint.Native;
using Jint.Runtime;
using WeifenLuo.WinFormsUI.Docking;

namespace JintDebugger
{
    public partial class OutputControl : DockContent
    {
        public OutputControl()
        {
            Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            const string consolas = "Consolas";

            var font = new Font(consolas, _textEditor.Font.Size);

            if (font.FontFamily.Name == consolas)
                _textEditor.Font = font;
        }

        internal void ClearOutput()
        {
            _textEditor.Text = null;
        }

        public IFirebugConsoleOutput CreateFirebugConsoleOutput(Engine engine)
        {
            if (engine == null)
                throw new ArgumentNullException(nameof(engine));

            return new ConsoleOutput(engine, _textEditor);
        }

        private class ConsoleOutput : IFirebugConsoleOutput
        {
            private readonly Engine _engine;
            private readonly TextBox _textEditor;

            private static readonly Regex NewlineRe = new Regex("\r?\n", RegexOptions.Compiled);

            private int _indentation;
            private readonly int _indent;

            public ConsoleOutput(Engine engine, TextBox textEditor)
            {
                _engine = engine;
                _textEditor = textEditor;
                _indent = 2;
            }

            public void Log(FirebugConsoleMessageStyle style, string value)
            {
                value = NewlineRe.Replace(value ?? "", p => Environment.NewLine);

                _textEditor.BeginInvoke(new Action<string>(AppendText), value);
            }

            private void AppendText(string message)
            {
                string indent = new string(' ', _indentation);

                foreach (string line in NewlineRe.Split(message))
                {
                    _textEditor.AppendText(indent + line);
                    _textEditor.AppendText(Environment.NewLine);
                }
            }

            public void Clear()
            {
                _textEditor.BeginInvoke(new Action(_textEditor.Clear));
            }

            public void StartGroup(string title, bool initiallyCollapsed)
            {
                Log(FirebugConsoleMessageStyle.Regular, title);
                _indentation = Math.Max(_indentation + _indent, 0);
            }

            public void EndGroup()
            {
                _indentation = Math.Max(_indentation - _indent, 0);
            }
        }
    }
}
