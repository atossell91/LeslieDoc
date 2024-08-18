using PdfSharp.Drawing;

namespace LeslieDoc {
    public interface IDrawable {
        void Draw(XGraphics gfx);
    }
}