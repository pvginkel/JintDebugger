using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace JintDebugger
{
    internal class CaretMark : Bookmark
    {
        public CaretMark(IDocument document, TextLocation location)
            : base(document, location)
        {
        }

        public CaretMark(IDocument document, TextLocation location, bool isEnabled)
            : base(document, location, isEnabled)
        {
        }

        public override void Draw(IconBarMargin margin, System.Drawing.Graphics g, System.Drawing.Point p)
        {
            margin.DrawArrow(g, p.Y);
        }

        public override bool Click(System.Windows.Forms.Control parent, System.Windows.Forms.MouseEventArgs e)
        {
            return false;
        }
    }
}
