namespace JintDebugger
{
    partial class ExceptionForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._exceptionThrown = new System.Windows.Forms.Label();
            this._additionalInformation = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._dockPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._exceptionThrown, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._additionalInformation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._cancelButton, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(538, 330);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _exceptionThrown
            // 
            this._exceptionThrown.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this._exceptionThrown, 2);
            this._exceptionThrown.Location = new System.Drawing.Point(3, 5);
            this._exceptionThrown.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._exceptionThrown.Name = "_exceptionThrown";
            this._exceptionThrown.Size = new System.Drawing.Size(109, 13);
            this._exceptionThrown.TabIndex = 0;
            this._exceptionThrown.Text = "Exception thrown: {0}";
            // 
            // _additionalInformation
            // 
            this._additionalInformation.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this._additionalInformation, 2);
            this._additionalInformation.Location = new System.Drawing.Point(3, 28);
            this._additionalInformation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._additionalInformation.Name = "_additionalInformation";
            this._additionalInformation.Size = new System.Drawing.Size(127, 13);
            this._additionalInformation.TabIndex = 1;
            this._additionalInformation.Text = "Additional information: {0}";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(460, 304);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Close";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _dockPanel
            // 
            this._dockPanel.AllowEndUserDocking = false;
            this.tableLayoutPanel1.SetColumnSpan(this._dockPanel, 2);
            this._dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this._dockPanel.Location = new System.Drawing.Point(3, 49);
            this._dockPanel.Name = "_dockPanel";
            this._dockPanel.Size = new System.Drawing.Size(532, 249);
            this._dockPanel.TabIndex = 3;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(556, 348);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JavaScript Exception";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _exceptionThrown;
        private System.Windows.Forms.Label _additionalInformation;
        private System.Windows.Forms.Button _cancelButton;
        private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;
    }
}