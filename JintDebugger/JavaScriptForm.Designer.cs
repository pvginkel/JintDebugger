namespace JintDebugger
{
    partial class JavaScriptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusCol = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusCh = new System.Windows.Forms.ToolStripStatusLabel();
            this._debugToolStrip = new System.Windows.Forms.ToolStrip();
            this._run = new System.Windows.Forms.ToolStripButton();
            this._break = new System.Windows.Forms.ToolStripButton();
            this._stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._stepInto = new System.Windows.Forms.ToolStripButton();
            this._stepOver = new System.Windows.Forms.ToolStripButton();
            this._stepOut = new System.Windows.Forms.ToolStripButton();
            this._menu = new System.Windows.Forms.MenuStrip();
            this._file = new System.Windows.Forms.ToolStripMenuItem();
            this._fileNew = new System.Windows.Forms.ToolStripMenuItem();
            this._fileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._fileSave = new System.Windows.Forms.ToolStripMenuItem();
            this._fileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this._fileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this._fileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._viewLocals = new System.Windows.Forms.ToolStripMenuItem();
            this._viewGlobals = new System.Windows.Forms.ToolStripMenuItem();
            this._viewCallStack = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._debugRun = new System.Windows.Forms.ToolStripMenuItem();
            this._debugBreak = new System.Windows.Forms.ToolStripMenuItem();
            this._debugStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this._debugStepInto = new System.Windows.Forms.ToolStripMenuItem();
            this._debugStepOver = new System.Windows.Forms.ToolStripMenuItem();
            this._debugStepOut = new System.Windows.Forms.ToolStripMenuItem();
            this._window = new System.Windows.Forms.ToolStripMenuItem();
            this._windowNextTab = new System.Windows.Forms.ToolStripMenuItem();
            this._windowPreviousTab = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip.SuspendLayout();
            this._debugToolStrip.SuspendLayout();
            this._menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dockPanel
            // 
            this._dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this._dockPanel.Location = new System.Drawing.Point(0, 49);
            this._dockPanel.Name = "_dockPanel";
            this._dockPanel.Size = new System.Drawing.Size(691, 444);
            this._dockPanel.TabIndex = 1;
            this._dockPanel.ActiveDocumentChanged += new System.EventHandler(this._dockPanel_ActiveDocumentChanged);
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel,
            this.toolStripStatusLabel2,
            this._statusLine,
            this.toolStripStatusLabel3,
            this._statusCol,
            this.toolStripStatusLabel1,
            this._statusCh});
            this._statusStrip.Location = new System.Drawing.Point(0, 493);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(691, 22);
            this._statusStrip.SizingGrip = false;
            this._statusStrip.TabIndex = 3;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _statusLabel
            // 
            this._statusLabel.ForeColor = System.Drawing.Color.White;
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(609, 17);
            this._statusLabel.Spring = true;
            this._statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel2.Text = "Ln";
            // 
            // _statusLine
            // 
            this._statusLine.ForeColor = System.Drawing.Color.White;
            this._statusLine.Name = "_statusLine";
            this._statusLine.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel3.Text = "Col";
            // 
            // _statusCol
            // 
            this._statusCol.ForeColor = System.Drawing.Color.White;
            this._statusCol.Name = "_statusCol";
            this._statusCol.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel1.Text = "Ch";
            // 
            // _statusCh
            // 
            this._statusCh.ForeColor = System.Drawing.Color.White;
            this._statusCh.Name = "_statusCh";
            this._statusCh.Size = new System.Drawing.Size(0, 17);
            // 
            // _debugToolStrip
            // 
            this._debugToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._debugToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._run,
            this._break,
            this._stop,
            this.toolStripSeparator2,
            this._stepInto,
            this._stepOver,
            this._stepOut});
            this._debugToolStrip.Location = new System.Drawing.Point(0, 24);
            this._debugToolStrip.Name = "_debugToolStrip";
            this._debugToolStrip.Size = new System.Drawing.Size(691, 25);
            this._debugToolStrip.TabIndex = 3;
            this._debugToolStrip.Text = "toolStrip1";
            // 
            // _run
            // 
            this._run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._run.Image = global::JintDebugger.NeutralResources._continue;
            this._run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._run.Name = "_run";
            this._run.Size = new System.Drawing.Size(23, 22);
            this._run.Text = "Run";
            this._run.Click += new System.EventHandler(this._run_Click);
            // 
            // _break
            // 
            this._break.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._break.Image = global::JintDebugger.NeutralResources._break;
            this._break.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._break.Name = "_break";
            this._break.Size = new System.Drawing.Size(23, 22);
            this._break.Text = "Break next statement";
            this._break.Click += new System.EventHandler(this._break_Click);
            // 
            // _stop
            // 
            this._stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._stop.Image = global::JintDebugger.NeutralResources.stop_process;
            this._stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._stop.Name = "_stop";
            this._stop.Size = new System.Drawing.Size(23, 22);
            this._stop.Text = "Stop program";
            this._stop.Click += new System.EventHandler(this._stop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _stepInto
            // 
            this._stepInto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._stepInto.Image = global::JintDebugger.NeutralResources.step_into;
            this._stepInto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._stepInto.Name = "_stepInto";
            this._stepInto.Size = new System.Drawing.Size(23, 22);
            this._stepInto.Text = "Step into";
            this._stepInto.Click += new System.EventHandler(this._stepInto_Click);
            // 
            // _stepOver
            // 
            this._stepOver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._stepOver.Image = global::JintDebugger.NeutralResources.step_over;
            this._stepOver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._stepOver.Name = "_stepOver";
            this._stepOver.Size = new System.Drawing.Size(23, 22);
            this._stepOver.Text = "Step over";
            this._stepOver.Click += new System.EventHandler(this._stepOver_Click);
            // 
            // _stepOut
            // 
            this._stepOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._stepOut.Image = global::JintDebugger.NeutralResources.step_out;
            this._stepOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._stepOut.Name = "_stepOut";
            this._stepOut.Size = new System.Drawing.Size(23, 22);
            this._stepOut.Text = "Step out";
            this._stepOut.Click += new System.EventHandler(this._stepOut_Click);
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._file,
            this.viewToolStripMenuItem,
            this.debugToolStripMenuItem,
            this._window});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(691, 24);
            this._menu.TabIndex = 0;
            this._menu.Text = "menuStrip1";
            // 
            // _file
            // 
            this._file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileNew,
            this._fileOpen,
            this.toolStripMenuItem1,
            this._fileSave,
            this._fileSaveAs,
            this.toolStripMenuItem2,
            this._fileClose,
            this.toolStripMenuItem5,
            this._fileExit});
            this._file.Name = "_file";
            this._file.Size = new System.Drawing.Size(37, 20);
            this._file.Text = "&File";
            // 
            // _fileNew
            // 
            this._fileNew.Name = "_fileNew";
            this._fileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._fileNew.Size = new System.Drawing.Size(186, 22);
            this._fileNew.Text = "&New";
            this._fileNew.Click += new System.EventHandler(this._fileNew_Click);
            // 
            // _fileOpen
            // 
            this._fileOpen.Name = "_fileOpen";
            this._fileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._fileOpen.Size = new System.Drawing.Size(186, 22);
            this._fileOpen.Text = "&Open";
            this._fileOpen.Click += new System.EventHandler(this._fileOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // _fileSave
            // 
            this._fileSave.Name = "_fileSave";
            this._fileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._fileSave.Size = new System.Drawing.Size(186, 22);
            this._fileSave.Text = "&Save";
            this._fileSave.Click += new System.EventHandler(this._fileSave_Click);
            // 
            // _fileSaveAs
            // 
            this._fileSaveAs.Name = "_fileSaveAs";
            this._fileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this._fileSaveAs.Size = new System.Drawing.Size(186, 22);
            this._fileSaveAs.Text = "Save &As";
            this._fileSaveAs.Click += new System.EventHandler(this._fileSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // _fileClose
            // 
            this._fileClose.Name = "_fileClose";
            this._fileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this._fileClose.Size = new System.Drawing.Size(186, 22);
            this._fileClose.Text = "&Close";
            this._fileClose.Click += new System.EventHandler(this._fileClose_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(183, 6);
            // 
            // _fileExit
            // 
            this._fileExit.Name = "_fileExit";
            this._fileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._fileExit.Size = new System.Drawing.Size(186, 22);
            this._fileExit.Text = "E&xit";
            this._fileExit.Click += new System.EventHandler(this._fileExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewLocals,
            this._viewGlobals,
            this._viewCallStack});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // _viewLocals
            // 
            this._viewLocals.Name = "_viewLocals";
            this._viewLocals.Size = new System.Drawing.Size(125, 22);
            this._viewLocals.Text = "&Locals";
            this._viewLocals.Click += new System.EventHandler(this._viewLocals_Click);
            // 
            // _viewGlobals
            // 
            this._viewGlobals.Name = "_viewGlobals";
            this._viewGlobals.Size = new System.Drawing.Size(125, 22);
            this._viewGlobals.Text = "&Globals";
            this._viewGlobals.Click += new System.EventHandler(this._viewGlobals_Click);
            // 
            // _viewCallStack
            // 
            this._viewCallStack.Name = "_viewCallStack";
            this._viewCallStack.Size = new System.Drawing.Size(125, 22);
            this._viewCallStack.Text = "&Call Stack";
            this._viewCallStack.Click += new System.EventHandler(this._viewCallStack_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._debugRun,
            this._debugBreak,
            this._debugStop,
            this.toolStripMenuItem4,
            this._debugStepInto,
            this._debugStepOver,
            this._debugStepOut});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "&Debug";
            // 
            // _debugRun
            // 
            this._debugRun.Image = global::JintDebugger.NeutralResources.start;
            this._debugRun.Name = "_debugRun";
            this._debugRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._debugRun.Size = new System.Drawing.Size(177, 22);
            this._debugRun.Text = "&Run";
            this._debugRun.Click += new System.EventHandler(this._run_Click);
            // 
            // _debugBreak
            // 
            this._debugBreak.Image = global::JintDebugger.NeutralResources._break;
            this._debugBreak.Name = "_debugBreak";
            this._debugBreak.Size = new System.Drawing.Size(177, 22);
            this._debugBreak.Text = "&Break";
            this._debugBreak.Click += new System.EventHandler(this._break_Click);
            // 
            // _debugStop
            // 
            this._debugStop.Image = global::JintDebugger.NeutralResources.stop_process;
            this._debugStop.Name = "_debugStop";
            this._debugStop.Size = new System.Drawing.Size(177, 22);
            this._debugStop.Text = "&Stop";
            this._debugStop.Click += new System.EventHandler(this._stop_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(174, 6);
            // 
            // _debugStepInto
            // 
            this._debugStepInto.Image = global::JintDebugger.NeutralResources.step_into;
            this._debugStepInto.Name = "_debugStepInto";
            this._debugStepInto.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this._debugStepInto.Size = new System.Drawing.Size(177, 22);
            this._debugStepInto.Text = "Step &Into";
            this._debugStepInto.Click += new System.EventHandler(this._stepInto_Click);
            // 
            // _debugStepOver
            // 
            this._debugStepOver.Image = global::JintDebugger.NeutralResources.step_over;
            this._debugStepOver.Name = "_debugStepOver";
            this._debugStepOver.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this._debugStepOver.Size = new System.Drawing.Size(177, 22);
            this._debugStepOver.Text = "Step &Over";
            this._debugStepOver.Click += new System.EventHandler(this._stepOver_Click);
            // 
            // _debugStepOut
            // 
            this._debugStepOut.Image = global::JintDebugger.NeutralResources.step_out;
            this._debugStepOut.Name = "_debugStepOut";
            this._debugStepOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F11)));
            this._debugStepOut.Size = new System.Drawing.Size(177, 22);
            this._debugStepOut.Text = "Step O&ut";
            this._debugStepOut.Click += new System.EventHandler(this._stepOut_Click);
            // 
            // _window
            // 
            this._window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._windowNextTab,
            this._windowPreviousTab});
            this._window.Name = "_window";
            this._window.Size = new System.Drawing.Size(63, 20);
            this._window.Text = "&Window";
            // 
            // _windowNextTab
            // 
            this._windowNextTab.Name = "_windowNextTab";
            this._windowNextTab.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Tab)));
            this._windowNextTab.Size = new System.Drawing.Size(226, 22);
            this._windowNextTab.Text = "&Next Tab";
            this._windowNextTab.Click += new System.EventHandler(this._windowNextTab_Click);
            // 
            // _windowPreviousTab
            // 
            this._windowPreviousTab.Name = "_windowPreviousTab";
            this._windowPreviousTab.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Tab)));
            this._windowPreviousTab.Size = new System.Drawing.Size(226, 22);
            this._windowPreviousTab.Text = "&Previous Tab";
            this._windowPreviousTab.Click += new System.EventHandler(this._windowPreviousTab_Click);
            // 
            // JavaScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 515);
            this.Controls.Add(this._dockPanel);
            this.Controls.Add(this._debugToolStrip);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menu);
            this.MainMenuStrip = this._menu;
            this.Name = "JavaScriptForm";
            this.Text = "JavaScript Console";
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._debugToolStrip.ResumeLayout(false);
            this._debugToolStrip.PerformLayout();
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _file;
        private System.Windows.Forms.ToolStripMenuItem _fileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _fileSave;
        private System.Windows.Forms.ToolStripMenuItem _fileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem _fileClose;
        private System.Windows.Forms.ToolStripMenuItem _fileExit;
        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;
        private System.Windows.Forms.ToolStripMenuItem _fileNew;
        private System.Windows.Forms.ToolStripMenuItem _window;
        private System.Windows.Forms.ToolStripMenuItem _windowNextTab;
        private System.Windows.Forms.ToolStripMenuItem _windowPreviousTab;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel _statusLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel _statusCol;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel _statusCh;
        private System.Windows.Forms.ToolStrip _debugToolStrip;
        private System.Windows.Forms.ToolStripButton _run;
        private System.Windows.Forms.ToolStripButton _break;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _stepInto;
        private System.Windows.Forms.ToolStripButton _stepOver;
        private System.Windows.Forms.ToolStripButton _stepOut;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _viewLocals;
        private System.Windows.Forms.ToolStripMenuItem _viewGlobals;
        private System.Windows.Forms.ToolStripMenuItem _viewCallStack;
        private System.Windows.Forms.ToolStripButton _stop;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _debugRun;
        private System.Windows.Forms.ToolStripMenuItem _debugBreak;
        private System.Windows.Forms.ToolStripMenuItem _debugStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem _debugStepInto;
        private System.Windows.Forms.ToolStripMenuItem _debugStepOver;
        private System.Windows.Forms.ToolStripMenuItem _debugStepOut;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    }
}

