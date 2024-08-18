using LeslieDoc.Lines;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public class BorderStyle {
        public static readonly XColor DefaultColor = XBrushes.Black.Color;
        public LineStyle TopBorderType { get; set; } = null;
        public XColor TopBorderColor { get; set; } = DefaultColor;
        public LineStyle BottomBorderType { get; set; } = null;
        public XColor BottomBorderColor { get; set; } = DefaultColor;
        public LineStyle LeftBorderType { get; set; } = null;
        public XColor LeftBorderColor { get; set; } = DefaultColor;
        public LineStyle RightBorderType { get; set; } = null;
        public XColor RightBorderColor { get; set; } = DefaultColor;
    }
}