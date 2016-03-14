using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using Jint.Runtime.Debugger;

namespace JintDebugger
{
    internal interface IJintSessionCallback
    {
        Continuation ProcessStep(Engine engine, DebugInformation debugInformation, BreakType breakType);
    }
}
