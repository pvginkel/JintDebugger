using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    internal interface IHasActiveEditor
    {
        IEditor ActiveEditor { get; }
        event EventHandler ActiveEditorChanged;
    }
}
