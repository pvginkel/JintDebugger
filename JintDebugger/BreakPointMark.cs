using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace JintDebugger
{
    internal class BreakPointMark : ImageBookmark
    {
        private static readonly Image Breakpoint = NeutralResources.breakpoint;

        public bool IsHealthy { get; set; }

        public event EventHandler Removed;

        protected virtual void OnRemoved(EventArgs e)
        {
            Removed?.Invoke(this, e);
        }

        public BreakPointMark(IDocument document, TextLocation location)
            : base(document, Breakpoint, location)
        {
            IsHealthy = true;
        }

        public override bool Click(Control parent, MouseEventArgs e)
        {
            bool result = base.Click(parent, e);

            if (result)
                OnRemoved(EventArgs.Empty);

            return result;
        }
    }
}
