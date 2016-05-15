using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemEx.Windows.Forms;
using Jint.Native;
using Jint.Runtime.Debugger;
using WeifenLuo.WinFormsUI.Docking;

namespace JintDebugger
{
    internal partial class VariablesControl : DockContent
    {
        private DebugInformation _displayedLocalsSource;

        public VariablesControl()
        {
            Font = SystemFonts.MessageBoxFont;

            InitializeComponent();

            VisualStyleUtil.StyleListView(_listView);
        }

        public void ResetVariables()
        {
            _listView.Enabled = false;

            _displayedLocalsSource = null;
        }

        public void LoadVariables(DebugInformation debug, VariablesMode mode)
        {
            if (_displayedLocalsSource == debug)
                return;

            _displayedLocalsSource = debug;

            _listView.Enabled = true;

            using (_listView.PreservePosition())
            {
                _listView.BeginUpdate();

                _listView.Items.Clear();

                var variables = mode == VariablesMode.Locals ? debug.Locals : debug.Globals;

                foreach (var item in variables)
                {
                    AddVariable(item.Key, item.Value);
                }

                _listView.EndUpdate();
            }
        }

        private void AddVariable(string name, JsValue value)
        {
            _listView.Items.Add(new ListViewItem
            {
                Text = name,
                SubItems =
                {
                    value.ToString(),
                    value.Type.ToString()
                }
            });
        }

        private void _listView_SizeChanged(object sender, EventArgs e)
        {
            int width = _listView.ClientSize.Width - 6;

            foreach (ColumnHeader column in _listView.Columns)
            {
                if (column != _valueHeader)
                    width -= column.Width;
            }

            _valueHeader.Width = Math.Max(width, 100);
        }
    }
}
