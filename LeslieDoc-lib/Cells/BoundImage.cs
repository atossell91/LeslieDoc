using PdfSharp.Drawing;

namespace LeslieDoc {
    public class BoundImage : IDrawableRelative
    {
        public XImage Image { get; set; }
        public void Draw(XGraphics gfx, PositionInfo parentPosition)
        {
            gfx.DrawImage(Image, 
                new XRect(parentPosition.Location, parentPosition.Size));
        }
    }
}