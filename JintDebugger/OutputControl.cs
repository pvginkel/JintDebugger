using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace JintDebugger
{
    public partial class OutputControl : DockContent
    {
        public OutputControl()
        {
            Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            Console.SetOut(new RedirectingTextWriter(_textEditor));

            const string consolas = "Consolas";

            var font = new Font(consolas, _textEditor.Font.Size);

            if (font.FontFamily.Name == consolas)
                _textEditor.Font = font;
        }

        internal void ClearOutput()
        {
            _textEditor.Text = null;
        }

        private class RedirectingTextWriter : TextWriter
        {
            private readonly TextBox _target;

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }

            public RedirectingTextWriter(TextBox target)
            {
                _target = target;
            }

            public override void Write(string value)
            {
                if (_target.InvokeRequired)
                {
                    _target.BeginInvoke(new Action<string>(Write), value);
                    return;
                }

                _target.AppendText(value);
                _target.Update();
            }

            public override void WriteLine(string value)
            {
                Write(value + Environment.NewLine);
            }
        }
    }
}
