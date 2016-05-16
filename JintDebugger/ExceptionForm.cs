using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint.Runtime;
using WeifenLuo.WinFormsUI.Docking;
using VS2012LightTheme = JintDebugger.Support.DockPanelTheme.VS2012LightTheme;

namespace JintDebugger
{
    public partial class ExceptionForm : SystemEx.Windows.Forms.Form
    {
        private ExceptionForm()
        {
            InitializeComponent();

            _dockPanel.Theme = new VS2012LightTheme
            {
                ShowWindowList = false
            };
        }

        public static void Show(IWin32Window owner, JavaScriptException exception)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            using (var form = new ExceptionForm())
            {
                form._exceptionThrown.Text = String.Format(form._exceptionThrown.Text, GetType(exception));
                form._additionalInformation.Text = String.Format(form._additionalInformation.Text, GetMessage(exception));
                form._location.Text = String.Format(form._location.Text, GetLocation(exception));

                if (exception.DebugInformation == null || exception.DebugInformation.Globals.Count == 0)
                {
                    form.Showing += (s, e) =>
                    {
                        int dockPanelHeight = form._dockPanel.Height;
                        form._dockPanel.Dispose();
                        form.MinimumSize = new Size(0, form.Height - dockPanelHeight);
                        form.MaximumSize = new Size(int.MaxValue, form.Height - dockPanelHeight);
                    };
                }
                else
                {
                    var callStack = new CallStackControl();
                    callStack.LoadCallStack(exception.DebugInformation);
                    form.ShowPanel(callStack);
                    var globalVariables = new VariablesControl
                    {
                        Text = "Globals"
                    };
                    globalVariables.LoadVariables(exception.DebugInformation, VariablesMode.Globals);
                    form.ShowPanel(globalVariables);
                    var localVariables = new VariablesControl
                    {
                        Text = "Locals"
                    };
                    localVariables.LoadVariables(exception.DebugInformation, VariablesMode.Locals);
                    form.ShowPanel(localVariables);

                    callStack.DockHandler.Activate();
                }

                form.ShowDialog(owner);
            }
        }

        private static string GetLocation(JavaScriptException exception)
        {
            if (exception.Location != null)
            {
                return String.Format(
                    "{0}({1},{2},{3},{4})",
                    exception.Location.Source.Source,
                    exception.Location.Start.Line,
                    exception.Location.Start.Column + 1,
                    exception.Location.End.Line,
                    exception.Location.End.Column + 1
                );
            }

            var stackTrace = exception.StackTrace;
            if (stackTrace != null)
                return stackTrace.Split(new[] { '\n' }, 2)[0].Trim();

            return "(none)";
        }

        private static string GetMessage(JavaScriptException exception)
        {
            if (exception.InnerException != null)
                return exception.InnerException.Message;
            if (exception.Error.IsObject())
            {
                if (String.IsNullOrEmpty(exception.Message))
                    return "(none)";
                return exception.Message;
            }
            return exception.Error.ToString();
        }

        private static string GetType(JavaScriptException exception)
        {
            if (exception.InnerException != null)
                return exception.InnerException.GetType().FullName;
            if (exception.Error.IsObject())
                return exception.Error.ToString();
            return exception.Error.Type.ToString();
        }

        private void ShowPanel(DockContent dockContent)
        {
            dockContent.DockAreas = DockAreas.Document;
            dockContent.CloseButton = false;
            dockContent.CloseButtonVisible = false;
            dockContent.AllowEndUserDocking = false;
            dockContent.Show(_dockPanel);
        }
    }
}
