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
    internal partial class GoToLineForm : SystemEx.Windows.Forms.Form
    {
        public int Line
        {
            get { return (int)_line.Value; }
            set { _line.Value = value; }
        }

        public GoToLineForm()
        {
            InitializeComponent();
        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            if (_line.Value.HasValue && _line.Value >= 1)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show(this, "Please enter a valid line number", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
