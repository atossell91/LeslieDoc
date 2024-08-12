using PdfSharp.Drawing;
using LeslieDoc.Lines;

namespace LeslieDoc {
    public class Cell {
        public XPoint Location { get; set; }
        public XSize Size { get; set; }

        public XColor BackgroundColor { get; set; } = XColor.Empty;

        public LineStyle TopBorder { get; set; } = null;
        public LineStyle BottomBorder { get; set; } = null;
        public LineStyle LeftBorder { get; set; } = null;
        public LineStyle RightBorder { get; set; } = null;

        public void Draw(XGraphics gfx)
        {
            XBrush brush = new XSolidBrush(BackgroundColor);
            gfx.DrawRectangle(brush,
                LeslieDoc.MillisToPdf(Location.X),
                LeslieDoc.MillisToPdf(Location.Y),
                LeslieDoc.MillisToPdf(Size.Width),
                LeslieDoc.MillisToPdf(Size.Height)
                );

            //  Draw the borders
            XPoint topRight = new XPoint(Location.X + Size.Width, Location.Y);
            XPoint bottomLeft = new XPoint(Location.X, Location.Y + Size.Height);
            XPoint bottomRight = new XPoint(Location.X + Size.Width, Location.Y + Size.Height);

            XColor color = XColor.FromArgb(0, 0, 0);
            this?.TopBorder(gfx, Location, topRight, color);
            this?.BottomBorder(gfx, bottomLeft, bottomRight, color);
            this?.LeftBorder(gfx, Location, bottomLeft, color);
            this?.RightBorder(gfx, topRight, bottomRight, color);
        }
    }
}