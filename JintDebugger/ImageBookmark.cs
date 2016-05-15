using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace JintDebugger
{
    internal abstract class ImageBookmark : Bookmark
    {
        private readonly Image _image;

        protected ImageBookmark(IDocument document, Image image, TextLocation location)
            : base(document, location)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            _image = image;
        }

        protected ImageBookmark(IDocument document, Image image, TextLocation location, bool isEnabled)
            : base(document, location, isEnabled)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            _image = image;
        }

        public override void Draw(IconBarMargin margin, Graphics g, Point p)
        {
            int size = Math.Min(16, margin.TextArea.TextView.FontHeight);

            var center = new Point(
                size / 2,
                p.Y + margin.TextArea.TextView.FontHeight / 2
            );

            var bounds = new Rectangle(
                center.X - _image.Width / 2,
                center.Y - _image.Height / 2,
                _image.Width,
                _image.Height
            );

            g.DrawImage(_image, bounds);
        }
    }
}
