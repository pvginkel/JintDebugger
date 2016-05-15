using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace JintDebugger
{
    internal class CaretMark : ImageBookmark
    {
        private static readonly Image ExecutionPointer = NeutralResources.executionPointer;

        public CaretMark(IDocument document, TextLocation location)
            : base(document, ExecutionPointer, location)
        {
        }

        public CaretMark(IDocument document, TextLocation location, bool isEnabled)
            : base(document, ExecutionPointer, location, isEnabled)
        {
        }

        public override bool Click(Control parent, MouseEventArgs e)
        {
            return false;
        }
    }
}
