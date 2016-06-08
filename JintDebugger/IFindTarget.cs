using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JintDebugger
{
    internal interface IFindTarget
    {
        FindResult Find(string findWhat, string replaceWith, FindOptions options, bool resetStartPoint);
    }
}
