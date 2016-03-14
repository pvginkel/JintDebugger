namespace JintDebugger
{
    partial class EditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorControl));
            this._textEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // _textEditor
            // 
            this._textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textEditor.IsIconBarVisible = true;
            this._textEditor.IsReadOnly = false;
            this._textEditor.Location = new System.Drawing.Point(0, 0);
            this._textEditor.Name = "_textEditor";
            this._textEditor.ShowLineNumbers = false;
            this._textEditor.Size = new System.Drawing.Size(596, 530);
            this._textEditor.TabIndex = 0;
            this._textEditor.TextChanged += new System.EventHandler(this._textEditor_TextChanged);
            // 
            // EditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 530);
            this.Controls.Add(this._textEditor);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorControl_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditorControl_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl _textEditor;
    }
}
