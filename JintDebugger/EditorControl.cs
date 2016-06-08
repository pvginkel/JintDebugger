using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Jint.Parser;
using Jint.Runtime.Debugger;
using WeifenLuo.WinFormsUI.Docking;

namespace JintDebugger
{
    internal partial class EditorControl : DockContent, IEditor, IFindTarget
    {
        private readonly IStatusBarProvider _statusBarProvider;
        private string _tabText;
        private EditorScript _script;
        private CaretMark _caretMark;

        public string FileName { get; private set; }
        public List<EditorBreakPoint> BreakPoints { get; }
        public bool IsDirty { get; private set; }

        public EditorScript Script
        {
            get { return _script; }
            set
            {
                _script = value;

                _textEditor.IsReadOnly = _script != null;

                if (_script != null)
                {
                    foreach (var breakPoint in BreakPoints)
                    {
                        breakPoint.BreakPoint = new BreakPoint(_script.Script, breakPoint.Line, breakPoint.Column);
                        _script.Engine.BreakPoints.Add(breakPoint.BreakPoint);
                    }
                }
                else
                {
                    foreach (var breakPoint in BreakPoints)
                    {
                        breakPoint.BreakPoint = null;
                    }

                    SetCaretMark(null);
                }
            }
        }

        public EditorControl(IStatusBarProvider statusBarProvider)
        {
            if (statusBarProvider == null)
                throw new ArgumentNullException(nameof(statusBarProvider));

            _statusBarProvider = statusBarProvider;
            BreakPoints = new List<EditorBreakPoint>();

            Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            _textEditor.SetHighlighting("JavaScript");

            const string consolas = "Consolas";

            var font = new Font(consolas, _textEditor.Font.Size);

            if (font.FontFamily.Name == consolas)
                _textEditor.Font = font;

            _textEditor.ActiveTextAreaControl.Caret.PositionChanged += Caret_PositionChanged;
            _textEditor.ActiveTextAreaControl.TextArea.IconBarMargin.MouseDown += IconBarMargin_MouseDown;

            SetTabText("New File");
        }

        void Caret_PositionChanged(object sender, EventArgs e)
        {
            UpdateLineCol();
        }

        void IconBarMargin_MouseDown(AbstractMargin sender, Point mousepos, MouseButtons mouseButtons)
        {
            if (mouseButtons != MouseButtons.Left)
                return;

            var textArea = _textEditor.ActiveTextAreaControl.TextArea;

            int yPos = mousepos.Y;
            int lineHeight = textArea.TextView.FontHeight;
            int lineNumber = (yPos + textArea.VirtualTop.Y) / lineHeight;

            if (BreakPoints.Any(p => p.Line == lineNumber + 1) || lineNumber >= textArea.Document.TotalNumberOfLines)
                return;

            string text = textArea.Document.GetText(textArea.Document.GetLineSegment(lineNumber));
            int offset = -1;

            for (int i = 0; i < text.Length; i++)
            {
                if (
                    !Char.IsWhiteSpace(text[i]) &&
                    text[i] != '/'
                )
                {
                    offset = i;
                    break;
                }
            }

            if (offset == -1)
                return;

            var breakPoint = new EditorBreakPoint(lineNumber + 1, offset);

            BreakPoints.Add(breakPoint);

            if (_script != null)
            {
                breakPoint.BreakPoint = new BreakPoint(Script.Script, lineNumber + 1, offset);
                _script.Engine.BreakPoints.Add(breakPoint.BreakPoint);
            }

            var document = _textEditor.Document;

            var mark = new BreakPointMark(
                document,
                new TextLocation(
                    offset,
                    lineNumber
                )
            );

            mark.Removed += (s, e) =>
            {
                BreakPoints.Remove(breakPoint);
                _script?.Engine.BreakPoints.Remove(breakPoint.BreakPoint);
            };

            document.BookmarkManager.AddMark(mark);

            _textEditor.Refresh();
        }

        public void UpdateDebugCaret(DebugInformation debugInformation)
        {
            if (debugInformation == null)
            {
                SetCaretMark(null);
                return;
            }

            var document = _textEditor.Document;

            int start = GetOffset(debugInformation.CurrentStatement.Location.Start);
            int end = GetOffset(debugInformation.CurrentStatement.Location.End);

            var position = document.OffsetToPosition(start);

            document.MarkerStrategy.AddMarker(new TextMarker(start, end - start, TextMarkerType.SolidBlock, Color.Yellow));
            _textEditor.ActiveTextAreaControl.TextArea.Caret.Position = position;

            SetCaretMark(new CaretMark(document, position));
        }

        private int GetOffset(Position location)
        {
            return _textEditor.Document.PositionToOffset(new TextLocation(
                location.Column, location.Line - 1
            ));
        }

        private void SetCaretMark(CaretMark caretMark)
        {
            if (caretMark == null)
            {
                if (_caretMark != null)
                {
                    _textEditor.Document.MarkerStrategy.RemoveAll(p => true);
                    _textEditor.Document.BookmarkManager.RemoveMark(_caretMark);
                    _caretMark = null;

                    _textEditor.Refresh();
                }
            }
            else
            {
                _caretMark = caretMark;
                _textEditor.Document.BookmarkManager.AddMark(_caretMark);

                _textEditor.Refresh();
            }
        }

        public void SetTabText(string tabText)
        {
            _tabText = tabText;

            if (IsDirty)
                tabText += "*";

            Text = TabText = tabText;
        }

        public void Open(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;

            SetTabText(Path.GetFileName(fileName));
            SetText(File.ReadAllText(fileName));
        }

        private void SetDirty(bool isDirty)
        {
            if (IsDirty != isDirty)
            {
                IsDirty = isDirty;
                SetTabText(_tabText);
            }
        }

        private void _textEditor_TextChanged(object sender, EventArgs e)
        {
            SetDirty(true);
        }

        public bool Save(string fileName)
        {
            if (fileName != null)
            {
                FileName = fileName;
                SetTabText(Path.GetFileName(fileName));
            }

            File.WriteAllText(FileName, _textEditor.Text);
            SetDirty(false);

            return true;
        }

        public string GetText()
        {
            return _textEditor.Text;
        }

        public int GetLine()
        {
            return _textEditor.ActiveTextAreaControl.Caret.Line + 1;
        }

        public void SetLine(int line)
        {
            _textEditor.ActiveTextAreaControl.Caret.Line = line - 1;
        }

        public FindResult Find(string findWhat, string replaceWith, FindOptions options, bool resetStartPoint)
        {
            if (findWhat == null)
                throw new ArgumentNullException("search");

            var textArea = _textEditor.ActiveTextAreaControl;
            var document = _textEditor.Document;
            string text = document.TextContent;

            int offset;

            if (options.HasFlag(FindOptions.Backwards))
            {
                if (resetStartPoint)
                    offset = text.Length;
                else
                    offset = textArea.Caret.Offset;
            }
            else
            {
                if (resetStartPoint)
                    offset = 0;
                else if (textArea.SelectionManager.HasSomethingSelected)
                    offset = textArea.SelectionManager.SelectionCollection.Last().EndOffset;
                else
                    offset = textArea.Caret.Offset;
            }

            int matchLength;
            bool found = FindInText(
                findWhat,
                options,
                text,
                offset,
                out offset,
                out matchLength
            );

            if (found)
            {
                if (replaceWith != null)
                {
                    _textEditor.Document.Replace(offset, matchLength, replaceWith);

                    MarkSpan(GetTextSpan(document, offset, replaceWith.Length));

                    return FindResult.Replaced;
                }

                MarkSpan(GetTextSpan(document, offset, matchLength));

                return FindResult.Found;
            }

            if (!resetStartPoint)
                return FindResult.EndOfDocument;

            return FindResult.NotFound;
        }

        private void MarkSpan(TextSpan span)
        {
            var textarea = _textEditor.ActiveTextAreaControl;
            var selectionManager = textarea.SelectionManager;

            var start = new TextLocation(span.StartIndex, span.StartLine);

            textarea.Caret.Position = start;

            selectionManager.SetSelection(
                start,
                new TextLocation(span.EndIndex, span.EndLine)
            );
        }

        private TextSpan GetTextSpan(IDocument document, int offset, int length)
        {
            var start = document.OffsetToPosition(offset);
            var end = document.OffsetToPosition(offset + length);

            return new TextSpan(start.Line, start.Column, end.Line, end.Column);
        }

        private bool FindInText(string find, FindOptions options, string text, int offset, out int found, out int matchLength)
        {
            found = 0;
            matchLength = 0;

            if (find == null)
                throw new ArgumentNullException("find");
            if (text == null)
                throw new ArgumentNullException("text");

            string pattern =
                options.HasFlag(FindOptions.RegExp)
                ? find
                : Regex.Escape(find);

            if (options.HasFlag(FindOptions.WholeWord))
                pattern = @"\b" + pattern + @"\b";

            var regexOptions = RegexOptions.Multiline;

            if (!options.HasFlag(FindOptions.MatchCase))
                regexOptions |= RegexOptions.IgnoreCase;
            if (options.HasFlag(FindOptions.Backwards))
                regexOptions |= RegexOptions.RightToLeft;

            var match = new Regex(pattern, regexOptions).Match(text, offset);

            bool isFound = match.Success;

            if (isFound)
            {
                found = match.Index;
                matchLength = match.Length;
            }

            return isFound;
        }

        public string GetSelectedText()
        {
            return _textEditor.ActiveTextAreaControl.SelectionManager.SelectedText;
        }

        public void SetText(string text)
        {
            _textEditor.Text = text;

            SetDirty(false);
        }

        public bool Save()
        {
            if (FileName == null)
                return SaveAs();

            return Save(null);
        }

        public bool SaveAs()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.AddExtension = true;
                dialog.CheckPathExists = true;
                dialog.Filter = JavaScriptForm.FileDialogFilter;
                dialog.OverwritePrompt = true;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                    return Save(dialog.FileName);
            }

            return false;
        }

        private void EditorControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            e.Cancel = !PerformSaveIfDirty();
        }

        private bool PerformSaveIfDirty()
        {
            if (IsDirty)
            {
                var result = MessageBox.Show(
                    this,
                    "Do you want to save your changes?",
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                switch (result)
                {
                    case DialogResult.Yes:
                        if (!Save())
                            return false;
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            return true;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            UpdateLineCol();
        }

        private void UpdateLineCol()
        {
            var position = _textEditor.ActiveTextAreaControl.Caret.Position;
            var line = _textEditor.Document.GetLineSegment(position.Line);
            int chars = _textEditor.Document.GetText(line).Substring(0, position.Column).Replace("\t", "    ").Length;

            _statusBarProvider.SetLineColumn(
                position.Line + 1, chars + 1, position.Column + 1
            );
        }

        private void EditorControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Script = null;

            ((JavaScriptForm)Parent.FindForm()).OnEditorClosed(new EditorEventArgs(this));
        }

        public void Close(bool force)
        {
            IsDirty = false;

            Close();
        }
    }
}
