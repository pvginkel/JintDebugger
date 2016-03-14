using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JintDebugger.Demo
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new JavaScriptForm();

            form.Shown += (s, e) =>
            {
                foreach (string fileName in args.Where(p => p.EndsWith(".js") && File.Exists(p)))
                {
                    form.OpenEditor(fileName);
                }
            };

            Application.Run(form);
        }
    }
}
