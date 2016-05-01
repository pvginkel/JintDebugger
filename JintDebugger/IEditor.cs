using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    public interface IEditor
    {
        string FileName { get; }
        bool IsDirty { get; }
        EditorScript Script { get; }

        void Open(string fileName);
        bool Save();
        bool Save(string fileName);
        bool SaveAs();
        void Close();
        void Close(bool force);
        string GetText();
        void Show();
    }
}
