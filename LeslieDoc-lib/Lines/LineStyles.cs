using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeslieDoc.Lines
{
    public delegate void LineStyle(XGraphics gfx, XPoint aPos, XPoint bPos, XColor color);
    public static class LineStyles
    {
        public const float BaseWidth = 0.5f;
        public static void StraightLine(XGraphics gfx, XPoint aPos, XPoint bPos, XColor color)
        {
            var pen = new XPen(color);
            pen.Width = BaseWidth;

            gfx.DrawLine(pen, aPos, bPos);
        }

        public static void DashedLine(XGraphics gfx, XPoint aPos, XPoint bPos, XColor color)
        {
            var pen = new XPen(color);
            pen.Width = BaseWidth;
            pen.DashStyle = XDashStyle.Dash;

            gfx.DrawLine(pen, aPos, bPos);
        }

        public static void DoubleLine(XGraphics gfx, XPoint aPos, XPoint bPos, XColor color)
        {
            var pen = new XPen(color);
            pen.Width = BaseWidth;

            gfx.DrawLine(pen, aPos, bPos);
            throw new Exceptions.NooneLikesYouException("Only a single line has been drawn. Get over it!");
        }
    }
}
