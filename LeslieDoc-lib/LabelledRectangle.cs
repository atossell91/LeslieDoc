using PdfSharp.Drawing;

namespace LeslieDoc {
    public class LabelledRectangle : IDrawableRelative {

        public TextElement Superscipt { get; set; }
        public TextElement Content { get; set; }

        public LabelledRectangle()
        {
            Superscipt = new TextElement();
            Content = new TextElement();

            Superscipt.RelativeTextHeight = 0.26;
            Superscipt.RelativeLocation = new XPoint(0.02, 0.26);

            Content.RelativeTextHeight = 0.6;
            Content.RelativeLocation = new XPoint(0.04, 0.84);
        }

        public void Draw(XGraphics gfx, PositionInfo parentPosition)
        {
            Superscipt.Draw(gfx, parentPosition);
            Content.Draw(gfx, parentPosition);
        }
    }
}