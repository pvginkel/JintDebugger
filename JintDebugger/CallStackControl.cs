using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemEx.Windows.Forms;
using Jint.Runtime.Debugger;
using WeifenLuo.WinFormsUI.Docking;

namespace JintDebugger
{
    public partial class CallStackControl : DockContent
    {
        private DebugInformation _displayedLocalsSource;

        public CallStackControl()
        {
            Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            VisualStyleUtil.StyleListView(_listView);
        }

        public void ResetCallStack()
        {
            _listView.Items.Clear();
            _listView.Enabled = false;

            _displayedLocalsSource = null;
        }

        public void LoadCallStack(DebugInformation debug)
        {
            if (_displayedLocalsSource == debug)
                return;

            _displayedLocalsSource = debug;

            _listView.Enabled = true;

            using (_listView.PreservePosition())
            {
                _listView.BeginUpdate();

                _listView.Items.Clear();

                foreach (string line in debug.CallStack)
                {
                    _listView.Items.Add(new ListViewItem(line));
                }

                _listView.EndUpdate();
            }
        }

        private void _listView_SizeChanged(object sender, EventArgs e)
        {
            _nameHeader.Width = _listView.ClientSize.Width - 6;
        }
    }
}
