using PdfSharp.Drawing;

namespace LeslieDoc {
    public class Cell {
        public XPoint Location { get; set; }
        public XSize Size { get; set; }
        public double Left { 
            get => Location.X;
        }
        public double Right { 
            get => Location.X + Size.Width;
        }
        public double Bottom { 
            get => Location.Y + Size.Height;
        }
        public double Top { 
            get => Location.Y;
        }
    }
}