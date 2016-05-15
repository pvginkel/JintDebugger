using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JintDebugger
{
    internal static class ListViewExtensions
    {
        public static IDisposable PreservePosition(this ListView self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            int position = 0;

            try
            {
                if (self.TopItem != null)
                    position = self.TopItem.Index;
            }
            catch
            {
                // Ignore.
            }

            return new Restorer(self, position);
        }

        private class Restorer : IDisposable
        {
            private readonly ListView _listView;
            private readonly int _position;
            private bool _disposed;

            public Restorer(ListView listView, int position)
            {
                _listView = listView;
                _position = position;
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    try
                    {
                        if (_listView.Items.Count > 0)
                            _listView.TopItem = _listView.Items[Math.Min(_position, _listView.Items.Count - 1)];
                    }
                    catch
                    {
                        // Ignore.
                    }

                    _disposed = true;
                }
            }
        }
    }
}
