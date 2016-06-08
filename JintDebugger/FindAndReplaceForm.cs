using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JintDebugger
{
    internal partial class FindAndReplaceForm : SystemEx.Windows.Forms.Form
    {
        private readonly IHasActiveEditor _owner;

        public string FindWhat
        {
            get { return _findWhat.Text; }
            set
            {
                _findWhat.Text = value;
                _findWhat.SelectAll();
            }
        }

        public string ReplaceWith
        {
            get { return _replaceWith.Text; }
            set
            {
                _replaceWith.Text = value;
                _replaceWith.SelectAll();
            }
        }

        public FindAndReplaceForm(IHasActiveEditor owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            _owner = owner;

            InitializeComponent();

            _owner.ActiveEditorChanged += _owner_ActiveEditorChanged;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Visible = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void _owner_ActiveEditorChanged(object sender, EventArgs e)
        {
            _container.Enabled = _owner.ActiveEditor != null;
        }

        private void _findWhat_TextChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }

        private void _replaceWith_TextChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }

        private void UpdateEnabled()
        {
            _find.Enabled = _findWhat.Text.Length > 0;
            _replace.Enabled = _findWhat.Text.Length > 0;
        }

        private void _find_Click(object sender, EventArgs e)
        {
            PerformFind(_findWhat.Text, null, GetOptions(FindOptions.Find));
        }

        private void PerformFind(string findWhat, string replaceWith, FindOptions options)
        {
            var result = ((IFindTarget)_owner.ActiveEditor).Find(findWhat, replaceWith, options, false);
            if (result == FindResult.EndOfDocument)
                result = ((IFindTarget)_owner.ActiveEditor).Find(findWhat, replaceWith, options, true);
            if (result == FindResult.NotFound)
                MessageBox.Show(this, "The specified text was not found", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private FindOptions GetOptions(FindOptions options)
        {
            if (_matchCase.Checked)
                options |= FindOptions.MatchCase;
            if (_matchWholeWord.Checked)
                options |= FindOptions.WholeWord;
            if (_useRegularExpressions.Checked)
                options |= FindOptions.RegExp;

            return options;
        }

        private void _replace_Click(object sender, EventArgs e)
        {
            PerformFind(_findWhat.Text, _replaceWith.Text, GetOptions(FindOptions.Replace));
        }

        public void FindNext()
        {
            if (_findWhat.Text.Length > 0)
                PerformFind(_findWhat.Text, null, GetOptions(FindOptions.Find));
        }

        public void FindPrevious()
        {
            if (_findWhat.Text.Length > 0)
                PerformFind(_findWhat.Text, null, GetOptions(FindOptions.Find | FindOptions.Backwards));
        }
    }
}
