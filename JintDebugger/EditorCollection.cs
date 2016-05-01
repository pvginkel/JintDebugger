using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace JintDebugger
{
    public class EditorCollection : IEnumerable<IEditor>
    {
        private readonly DockPanel _dockPanel;

        public int Count => this.Count();

        public IEditor this[int index] => this.Skip(index).First();

        internal EditorCollection(DockPanel dockPanel)
        {
            if (dockPanel == null)
                throw new ArgumentNullException(nameof(dockPanel));

            _dockPanel = dockPanel;
        }

        public IEnumerator<IEditor> GetEnumerator()
        {
            return _dockPanel.Documents.OfType<IEditor>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
