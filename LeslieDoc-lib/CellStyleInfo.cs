using System;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public class CellStyleInfo
    {
        public XColor BackgroundColour { get; set; } = XColor.Empty;
        public XColor BorderColour { get; set; } = XColor.Empty;
        public double BorderWidth { get; set; }
        public ILine LeftBorder { get; set; }
        public ILine RightBorder { get; set; }
        public ILine TopBorder { get; set; }
        public ILine BottomBorder { get; set; }
    }
}