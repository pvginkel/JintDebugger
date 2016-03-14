using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace JintDebugger
{
    internal class BreakPointMark : Bookmark
    {
        public bool IsHealthy { get; set; }
        public event EventHandler Removed;

        protected virtual void OnRemoved(EventArgs e)
        {
            var ev = Removed;
            if (ev != null)
                ev(this, e);
        }

        public BreakPointMark(IDocument document, TextLocation location)
            : base(document, location)
        {
            IsHealthy = true;
        }

        public override void Draw(IconBarMargin margin, System.Drawing.Graphics g, System.Drawing.Point p)
        {
            margin.DrawBreakpoint(g, p.Y, IsEnabled, IsHealthy);
        }

        public override bool Click(System.Windows.Forms.Control parent, System.Windows.Forms.MouseEventArgs e)
        {
            bool result = base.Click(parent, e);

            if (result)
                OnRemoved(EventArgs.Empty);

            return result;
        }
    }
}
