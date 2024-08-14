using PdfSharp.Drawing;

namespace LeslieDoc {
    public interface IDrawableRelative {
        void Draw(XGraphics gfx, PositionInfo parentPosition);
    }
}