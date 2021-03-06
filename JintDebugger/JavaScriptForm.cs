﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Jint;
using Jint.Parser;
using Jint.Runtime;
using Jint.Runtime.Debugger;
using WeifenLuo.WinFormsUI.Docking;
using VS2012LightTheme = JintDebugger.Support.DockPanelTheme.VS2012LightTheme;

namespace JintDebugger
{
    public partial class JavaScriptForm : SystemEx.Windows.Forms.Form, IStatusBarProvider, IHasActiveEditor
    {
        public const string FileDialogFilter = "JavaScript (*.js)|*.js|All Files (*.*)|*.*";
        private static readonly Color StatusBarNormalColor = Color.FromArgb(0, 122, 204);
        private static readonly Color StatusBarRunColor = Color.FromArgb(202, 81, 0);

        private readonly OutputControl _outputControl;
        private readonly VariablesControl _localsControl;
        private readonly VariablesControl _globalsControl;
        private readonly CallStackControl _callStackControl;
        private Debugger _debugger;
        private readonly Dictionary<Script, EditorControl> _debugControls = new Dictionary<Script, EditorControl>();
        private EditorControl _lastStepControl;
        private FindAndReplaceForm _findAndReplaceForm;
        private EventHandler _activeEditorChanged;

        protected new MenuStrip Menu => _menu;

        protected DockPanel DockPanel => _dockPanel;

        public EditorCollection Editors { get; }

        public event EngineCreatedEventHandler EngineCreated;

        private IEditor ActiveEditor => _dockPanel.ActiveDocument as IEditor;

        IEditor IHasActiveEditor.ActiveEditor => ActiveEditor;

        event EventHandler IHasActiveEditor.ActiveEditorChanged
        {
            add { _activeEditorChanged += value; }
            remove { _activeEditorChanged -= value; }
        }

        public event EditorEventHandler EditorOpened;

        public event EditorEventHandler EditorClosed;

        public JavaScriptForm()
        {
            InitializeComponent();

            Editors = new EditorCollection(_dockPanel);

            _dockPanel.Theme = new VS2012LightTheme();

            _outputControl = new OutputControl();

            _outputControl.Show(_dockPanel, DockState.DockBottom);

            _localsControl = new VariablesControl
            {
                Text = "Locals"
            };

            _localsControl.Show(_dockPanel, DockState.DockBottom);

            _globalsControl = new VariablesControl
            {
                Text = "Globals"
            };

            _globalsControl.Show(_dockPanel, DockState.DockBottom);

            _callStackControl = new CallStackControl();

            _callStackControl.Show(_dockPanel, DockState.DockBottom);

            ResetTabs();

            SetDebugger(null);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F3 | Keys.Control:
                    FindWithCurrent(true);
                    return true;
                case Keys.F3 | Keys.Shift | Keys.Control:
                    FindWithCurrent(false);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void SetDebugger(Debugger debugger)
        {
            _debugger?.Dispose();

            _debugger = debugger;

            if (_debugger != null)
            {
                _debugger.IsRunningChanged += _debugger_IsRunningChanged;
                _debugger.Stopped += _debugger_Stopped;
                _debugger.Stepped += _debugger_Stepped;
                _debugger.SourceLoaded += _debugger_SourceLoaded;
            }

            _viewLocals.Enabled =
            _viewGlobals.Enabled =
            _viewCallStack.Enabled =
                _debugger != null;

            _localsControl.DockHandler.IsHidden = _debugger == null;
            _globalsControl.DockHandler.IsHidden = _debugger == null;
            _callStackControl.DockHandler.IsHidden = _debugger == null;

            if (_debugger == null)
            {
                foreach (var control in _debugControls.Values.ToList())
                {
                    control?.Dispose();
                }

                _debugControls.Clear();

                foreach (var control in _dockPanel.Documents.OfType<EditorControl>())
                {
                    control.Script = null;
                }
            }

            UpdateEnabled();
        }

        private void _debugger_SourceLoaded(object sender, SourceLoadedEventArgs e)
        {
            // First see whether we have an editor that matches this script.

            foreach (var editor in _dockPanel.Documents.OfType<EditorControl>())
            {
                if (editor.FileName == e.Source.Source)
                {
                    editor.Script = new EditorScript(_debugger.Engine, e.Source);
                    return;
                }
            }

            // Otherwise, add an empty registration for later on.

            _debugControls.Add(e.Source, null);
        }

        private void _debugger_Stepped(object sender, JintDebuggerSteppedEventArgs e)
        {
            BeginInvoke(new Action(Stepped));
        }

        private void Stepped()
        {
            var script = _debugger.DebugInformation.CurrentStatement.Location.Source;

            var control =
                _dockPanel.Documents.OfType<EditorControl>().FirstOrDefault(p => p.Script?.Script == script) ??
                _debugControls[script];

            if (control == null)
            {
                control = new EditorControl(this);
                _debugControls[script] = control;

                control.SetTabText(script.Source ?? "(eval)");
                control.SetText(script.Code);
                control.Script = new EditorScript(_debugger.Engine, script);
                control.Show(_dockPanel, DockState.Document);
                control.Disposed += (s, ea) => _debugControls[script] = null;
            }

            if (_lastStepControl != null && _lastStepControl != control)
                _lastStepControl.UpdateDebugCaret(null);

            _lastStepControl = control;
            _lastStepControl.DockHandler.Activate();

            control.UpdateDebugCaret(_debugger.DebugInformation);
        }

        private void _debugger_IsRunningChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(IsRunningChanged));
        }

        private void IsRunningChanged()
        {
            if (_debugger?.DebugInformation != null)
            {
                LoadTabs(_debugger.DebugInformation);
            }
            else
            {
                ResetTabs();

                if (_lastStepControl != null)
                {
                    _lastStepControl.UpdateDebugCaret(null);
                    _lastStepControl = null;
                }
            }

            UpdateEnabled();
        }

        private void _debugger_Stopped(object sender, JintDebuggerStoppedEventArgs e)
        {
            BeginInvoke(new Action(() => Completed(e.Exception)));
        }

        private void Completed(Exception exception)
        {
            SetDebugger(null);

            if (exception == null || exception is ThreadAbortException || exception.InnerException is ThreadAbortException)
                return;

            var javaScriptException = exception as JavaScriptException;
            if (javaScriptException != null)
            {
                ExceptionForm.Show(this, javaScriptException);
                return;
            }

            MessageBox.Show(
                this,
                new StringBuilder()
                    .AppendLine("An exception occurred while executing the script:")
                    .AppendLine()
                    .Append(exception.Message).Append(" (").Append(exception.GetType().FullName).AppendLine(")")
                    .AppendLine()
                    .AppendLine(exception.StackTrace)
                    .ToString(),
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void ResetTabs()
        {
            _localsControl.ResetVariables();
            _globalsControl.ResetVariables();
            _callStackControl.ResetCallStack();
        }

        private void _fileNew_Click(object sender, EventArgs e)
        {
            OpenEditor(null);
        }

        private void _fileOpen_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Filter = FileDialogFilter;
                dialog.Multiselect = false;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    OpenEditor(dialog.FileName);
                }
            }
        }

        public IEditor FindEditor(string fileName)
        {
            if (fileName == null)
                return null;

            return Editors.FirstOrDefault(p => p.FileName.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        }

        public void OpenEditor()
        {
            OpenEditor(null);
        }

        public IEditor OpenEditor(string fileName)
        {
            var editor = (EditorControl)FindEditor(fileName);
            if (editor != null)
            {
                editor.Show();
            }
            else
            {
                editor = new EditorControl(this);

                if (fileName != null)
                    editor.Open(fileName);

                editor.Show(_dockPanel, DockState.Document);

                OnEditorOpened(new EditorEventArgs(editor));
            }

            return editor;
        }

        private void _dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }

        private void UpdateEnabled()
        {
            _activeEditorChanged?.Invoke(this, EventArgs.Empty);

            bool haveEditor = ActiveEditor != null && _debugger == null;

            _fileSave.Enabled = haveEditor;
            _fileSaveAs.Enabled = haveEditor;
            _fileClose.Enabled = haveEditor;
            _windowNextTab.Enabled = haveEditor;
            _windowPreviousTab.Enabled = haveEditor;
            _goToLine.Enabled = haveEditor;
            _findAndReplace.Enabled = haveEditor;
            _findNext.Enabled = haveEditor;
            _findPrevious.Enabled = haveEditor;

            if (_debugger == null)
            {
                _run.Enabled = _debugRun.Enabled = haveEditor;
                _break.Enabled = _debugBreak.Enabled = false;
                _stop.Enabled = _debugStop.Enabled = false;
                _stepInto.Enabled = _debugStepInto.Enabled = haveEditor;
                _stepOver.Enabled = _debugStepOver.Enabled = false;
                _stepOut.Enabled = _debugStepOut.Enabled = false;
            }
            else
            {
                _run.Enabled = _debugRun.Enabled = !_debugger.IsRunning;
                _break.Enabled = _debugBreak.Enabled = _debugger.IsRunning;
                _stop.Enabled = _debugStop.Enabled = true;
                _stepInto.Enabled = _debugStepInto.Enabled = !_debugger.IsRunning;
                _stepOver.Enabled = _debugStepOver.Enabled = !_debugger.IsRunning;
                _stepOut.Enabled = _debugStepOut.Enabled = !_debugger.IsRunning;
            }

            _statusStrip.BackColor = _debugger == null ? StatusBarNormalColor : StatusBarRunColor;
        }

        private void _fileSave_Click(object sender, EventArgs e)
        {
            ActiveEditor.Save();
        }

        private void _fileSaveAs_Click(object sender, EventArgs e)
        {
            ActiveEditor.SaveAs();
        }

        private void _fileClose_Click(object sender, EventArgs e)
        {
            ActiveEditor.Close();
        }

        private void _stop_Click(object sender, EventArgs e)
        {
            SetDebugger(null);
        }

        private void ClearOutput()
        {
            _outputControl.ClearOutput();
        }

        private void ActivateNextTab(bool forward)
        {
            var documents = new List<IDockContent>(_dockPanel.Documents);

            if (documents.Count == 0)
                return;

            int activeDocumentIndex = documents.IndexOf((IDockContent)ActiveEditor);

            if (activeDocumentIndex == -1)
                activeDocumentIndex = 0;
            else
            {
                activeDocumentIndex += (forward ? 1 : -1);

                if (activeDocumentIndex < 0)
                    activeDocumentIndex = documents.Count - 1;
                if (activeDocumentIndex >= documents.Count)
                    activeDocumentIndex = 0;
            }

            ((DockContent)documents[activeDocumentIndex]).Show(_dockPanel);
        }

        private void _windowNextTab_Click(object sender, EventArgs e)
        {
            ActivateNextTab(true);
        }

        private void _windowPreviousTab_Click(object sender, EventArgs e)
        {
            ActivateNextTab(false);
        }

        public void SetLineColumn(int? line, int? column, int? chars)
        {
            _statusLine.Text = line?.ToString();
            _statusCol.Text = column?.ToString();
            _statusCh.Text = chars?.ToString();
		}

        public void SetStatus(string status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetStatus), status);
            }
            else
            {
                _statusLabel.Text = status?.Replace("&", "&&");
                _statusStrip.Update();
            }
        }

        private void _fileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _viewLocals_Click(object sender, EventArgs e)
        {
            _localsControl.Show();
        }

        private void _viewGlobals_Click(object sender, EventArgs e)
        {
            _globalsControl.Show();
        }

        private void _viewCallStack_Click(object sender, EventArgs e)
        {
            _callStackControl.Close();
        }

        private void _break_Click(object sender, EventArgs e)
        {
            _debugger.Break();
        }

        private void _run_Click(object sender, EventArgs e)
        {
            if (_debugger == null)
                StartDebugger(false);
            else
                _debugger.Continue();
        }

        private void _stepInto_Click(object sender, EventArgs e)
        {
            if (_debugger == null)
                StartDebugger(true);
            else
                _debugger.Step(StepMode.Into);
        }

        private void _stepOver_Click(object sender, EventArgs e)
        {
            _debugger.Step(StepMode.Over);
        }

        private void StartDebugger(bool startBreaked)
        {
            foreach (var control in _dockPanel.Documents.OfType<EditorControl>())
            {
                control.Save();
            }

            ClearOutput();

            var debugger = new Debugger();

            SetDebugger(debugger);

            debugger.Run(
                ActiveEditor.FileName,
                ActiveEditor.GetText(),
                SetupEngine,
                startBreaked
            );
        }

        private void SetupEngine(Engine engine)
        {
            engine.SetValue("console", FirebugConsole.CreateFirebugConsole(engine, _outputControl.CreateFirebugConsoleOutput(engine)));

            OnEngineCreated(new EngineCreatedEventArgs(engine));
        }

        private void _stepOut_Click(object sender, EventArgs e)
        {
            _debugger.Step(StepMode.Out);
        }

        private void LoadTabs(DebugInformation debug)
        {
            _localsControl.LoadVariables(debug, VariablesMode.Locals);
            _globalsControl.LoadVariables(debug, VariablesMode.Globals);
            _callStackControl.LoadCallStack(debug);
        }

        protected virtual void OnEngineCreated(EngineCreatedEventArgs e)
        {
            EngineCreated?.Invoke(this, e);
        }

        protected virtual void OnEditorOpened(EditorEventArgs e)
        {
            EditorOpened?.Invoke(this, e);
        }

        protected internal virtual void OnEditorClosed(EditorEventArgs e)
        {
            EditorClosed?.Invoke(this, e);
        }

        private void _goToLine_Click(object sender, EventArgs e)
        {
            using (var form = new GoToLineForm())
            {
                form.Line = ActiveEditor.GetLine();
                if (form.ShowDialog(this) == DialogResult.OK)
                    ActiveEditor.SetLine(form.Line);
            }
        }

        private void _findAndReplace_Click(object sender, EventArgs e)
        {
            if (_findAndReplaceForm == null)
            {
                EnsureFindForm();
                _findAndReplaceForm.Show(this);
            }
            else
            {
                _findAndReplaceForm.Visible = true;
                _findAndReplaceForm.Focus();
            }


            if (!String.IsNullOrEmpty(ActiveEditor?.GetSelectedText()))
                _findAndReplaceForm.FindWhat = ActiveEditor.GetSelectedText();
            else
                _findAndReplaceForm.FindWhat = _findAndReplaceForm.FindWhat;
        }

        private void EnsureFindForm()
        {
            if (_findAndReplaceForm == null)
            {
                _findAndReplaceForm = new FindAndReplaceForm(this);
                _findAndReplaceForm.Disposed += (s, ea) => _findAndReplaceForm = null;
            }
        }

        private void FindWithCurrent(bool forward)
        {
            string selection = ActiveEditor?.GetSelectedText();
            if (!String.IsNullOrEmpty(selection))
            {
                EnsureFindForm();
                _findAndReplaceForm.FindWhat = selection;
                (forward ? _findNext : _findPrevious).PerformClick();
            }
        }

        private void _findNext_Click(object sender, EventArgs e)
        {
            if (_findAndReplaceForm == null)
                _findAndReplace.PerformClick();
            else if (ActiveEditor != null)
                _findAndReplaceForm.FindNext();
        }

        private void _findPrevious_Click(object sender, EventArgs e)
        {
            if (_findAndReplaceForm == null)
                _findAndReplace.PerformClick();
            else if (ActiveEditor != null)
                _findAndReplaceForm.FindPrevious();
        }

        private void JavaScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            bool anyDirty = false;

            foreach (var editor in _dockPanel.Documents.OfType<EditorControl>())
            {
                if (editor.IsDirty)
                {
                    anyDirty = true;
                    break;
                }
            }

            if (anyDirty)
            {
                var result = MessageBox.Show(this, "Do you want to save your change?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        foreach (var editor in _dockPanel.Documents.OfType<EditorControl>())
                        {
                            if (!editor.Save())
                            {
                                e.Cancel = true;
                                return;
                            }
                        }
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
        }
    }
}
