namespace JintDebugger
{
    partial class OutputControl
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
            this._textEditor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _textEditor
            // 
            this._textEditor.BackColor = System.Drawing.SystemColors.Window;
            this._textEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textEditor.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textEditor.Location = new System.Drawing.Point(0, 0);
            this._textEditor.Multiline = true;
            this._textEditor.Name = "_textEditor";
            this._textEditor.ReadOnly = true;
            this._textEditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textEditor.Size = new System.Drawing.Size(639, 512);
            this._textEditor.TabIndex = 0;
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 512);
            this.Controls.Add(this._textEditor);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OutputControl";
            this.TabText = "Output";
            this.Text = "Output";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textEditor;

    }
}