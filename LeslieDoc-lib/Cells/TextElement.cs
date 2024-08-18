using System;
using System.Drawing;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public class TextElement : IDrawableRelative
    {
        public XPoint RelativeLocation { get; set; }
        public Double RelativeTextHeight { get; set; }

        public string Text { get; set; }
        public string FontName { get; set; } = "Arial";
        public XBrush Brush { get; set; } = XBrushes.Black;

        public TextElement() {}

        public void Draw(XGraphics gfx, PositionInfo parentPosition)
        {
            double xPos = parentPosition.Location.X + RelativeLocation.X * parentPosition.Size.Width;
            double yPos = parentPosition.Location.Y + RelativeLocation.Y * parentPosition.Size.Height;
            double textHeight = RelativeTextHeight * parentPosition.Size.Height;

            XFont font = new XFont(FontName, textHeight);
            gfx.DrawString(Text, font, Brush, new XPoint(xPos, yPos));
        }
    }
}