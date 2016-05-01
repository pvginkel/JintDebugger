using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    public class EditorEventArgs : EventArgs
    {
        public IEditor Editor { get; }

        public EditorEventArgs(IEditor editor)
        {
            if (editor == null)
                throw new ArgumentNullException(nameof(editor));

            Editor = editor;
        }
    }

    public delegate void EditorEventHandler(object sender, EditorEventArgs e);
}
