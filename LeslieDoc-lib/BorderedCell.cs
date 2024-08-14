using PdfSharp.Drawing;

namespace LeslieDoc {
    public class BorderedCell : IDrawable
    {
        public PositionInfo PositionInfo { get; set; } = new PositionInfo();
        public IDrawableRelative CellContent { get; set; } = null;
        public BorderStyle BorderStyle  { get; set; } = new BorderStyle();
        public void Draw(XGraphics gfx)
        {
            CellContent?.Draw(gfx, PositionInfo);

            XPoint topleft = new XPoint(PositionInfo.Left, PositionInfo.Top);
            XPoint topright = new XPoint(PositionInfo.Right, PositionInfo.Top);
            XPoint bottomleft = new XPoint(PositionInfo.Left, PositionInfo.Bottom);
            XPoint bottomright = new XPoint(PositionInfo.Right, PositionInfo.Bottom);

            if (BorderStyle.TopBorderType != null)
                BorderStyle.TopBorderType(gfx, topleft, topright, BorderStyle.TopBorderColor);
            if (BorderStyle.BottomBorderType != null)
                BorderStyle.BottomBorderType(gfx, bottomleft, bottomright, BorderStyle.BottomBorderColor);
            if (BorderStyle.LeftBorderType != null)
                BorderStyle.LeftBorderType(gfx, topleft, bottomleft, BorderStyle.LeftBorderColor);
            if (BorderStyle.RightBorderType != null)
                BorderStyle.RightBorderType(gfx, topright, bottomright, BorderStyle.RightBorderColor);
        }
    }
}