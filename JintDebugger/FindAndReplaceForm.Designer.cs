namespace JintDebugger
{
    partial class FindAndReplaceForm
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
            this._container = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._findWhat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._replaceWith = new System.Windows.Forms.TextBox();
            this._find = new System.Windows.Forms.Button();
            this._replace = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._matchCase = new System.Windows.Forms.CheckBox();
            this._matchWholeWord = new System.Windows.Forms.CheckBox();
            this._useRegularExpressions = new System.Windows.Forms.CheckBox();
            this._container.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _container
            // 
            this._container.AutoSize = true;
            this._container.ColumnCount = 3;
            this._container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._container.Controls.Add(this.label1, 0, 0);
            this._container.Controls.Add(this._findWhat, 0, 1);
            this._container.Controls.Add(this.label2, 0, 2);
            this._container.Controls.Add(this._replaceWith, 0, 3);
            this._container.Controls.Add(this._find, 1, 5);
            this._container.Controls.Add(this._replace, 2, 5);
            this._container.Controls.Add(this.groupBox1, 0, 4);
            this._container.Dock = System.Windows.Forms.DockStyle.Fill;
            this._container.Location = new System.Drawing.Point(4, 4);
            this._container.Name = "_container";
            this._container.RowCount = 6;
            this._container.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._container.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._container.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._container.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._container.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._container.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._container.Size = new System.Drawing.Size(382, 222);
            this._container.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this._container.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // _findWhat
            // 
            this._container.SetColumnSpan(this._findWhat, 3);
            this._findWhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this._findWhat.Location = new System.Drawing.Point(3, 22);
            this._findWhat.Name = "_findWhat";
            this._findWhat.Size = new System.Drawing.Size(376, 20);
            this._findWhat.TabIndex = 1;
            this._findWhat.TextChanged += new System.EventHandler(this._findWhat_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this._container.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Replace with:";
            // 
            // _replaceWith
            // 
            this._container.SetColumnSpan(this._replaceWith, 3);
            this._replaceWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this._replaceWith.Location = new System.Drawing.Point(3, 67);
            this._replaceWith.Name = "_replaceWith";
            this._replaceWith.Size = new System.Drawing.Size(376, 20);
            this._replaceWith.TabIndex = 3;
            this._replaceWith.TextChanged += new System.EventHandler(this._replaceWith_TextChanged);
            // 
            // _find
            // 
            this._find.Location = new System.Drawing.Point(223, 196);
            this._find.Name = "_find";
            this._find.Size = new System.Drawing.Size(75, 23);
            this._find.TabIndex = 5;
            this._find.Text = "&Find Next";
            this._find.UseVisualStyleBackColor = true;
            this._find.Click += new System.EventHandler(this._find_Click);
            // 
            // _replace
            // 
            this._replace.Location = new System.Drawing.Point(304, 196);
            this._replace.Name = "_replace";
            this._replace.Size = new System.Drawing.Size(75, 23);
            this._replace.TabIndex = 6;
            this._replace.Text = "&Replace";
            this._replace.UseVisualStyleBackColor = true;
            this._replace.Click += new System.EventHandler(this._replace_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this._container.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(376, 97);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find &options";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._matchCase, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._matchWholeWord, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._useRegularExpressions, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _matchCase
            // 
            this._matchCase.AutoSize = true;
            this._matchCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._matchCase.Location = new System.Drawing.Point(3, 3);
            this._matchCase.Name = "_matchCase";
            this._matchCase.Size = new System.Drawing.Size(88, 18);
            this._matchCase.TabIndex = 0;
            this._matchCase.Text = "Match &case";
            this._matchCase.UseVisualStyleBackColor = true;
            // 
            // _matchWholeWord
            // 
            this._matchWholeWord.AutoSize = true;
            this._matchWholeWord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._matchWholeWord.Location = new System.Drawing.Point(3, 27);
            this._matchWholeWord.Name = "_matchWholeWord";
            this._matchWholeWord.Size = new System.Drawing.Size(119, 18);
            this._matchWholeWord.TabIndex = 1;
            this._matchWholeWord.Text = "Match &whole word";
            this._matchWholeWord.UseVisualStyleBackColor = true;
            // 
            // _useRegularExpressions
            // 
            this._useRegularExpressions.AutoSize = true;
            this._useRegularExpressions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._useRegularExpressions.Location = new System.Drawing.Point(3, 51);
            this._useRegularExpressions.Name = "_useRegularExpressions";
            this._useRegularExpressions.Size = new System.Drawing.Size(150, 18);
            this._useRegularExpressions.TabIndex = 2;
            this._useRegularExpressions.Text = "Us&e Regular Expressions";
            this._useRegularExpressions.UseVisualStyleBackColor = true;
            // 
            // FindAndReplaceForm
            // 
            this.AcceptButton = this._find;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(390, 230);
            this.Controls.Add(this._container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindAndReplaceForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find and Replace";
            this._container.ResumeLayout(false);
            this._container.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _container;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _findWhat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _replaceWith;
        private System.Windows.Forms.Button _find;
        private System.Windows.Forms.Button _replace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox _matchCase;
        private System.Windows.Forms.CheckBox _matchWholeWord;
        private System.Windows.Forms.CheckBox _useRegularExpressions;
    }
}