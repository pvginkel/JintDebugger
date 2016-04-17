using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    public interface IFirebugConsoleOutput
    {
        void Log(FirebugConsoleMessageStyle style, string value);

        void Clear();

        void StartGroup(string title, bool initiallyCollapsed);

        void EndGroup();
    }
}
