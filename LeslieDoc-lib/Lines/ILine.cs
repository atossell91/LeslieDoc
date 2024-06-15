using System.Net.NetworkInformation;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public interface ILine {
        void DrawLine(XGraphics gfx, XPen pen, XPoint p1, XPoint p2);    
    }
}