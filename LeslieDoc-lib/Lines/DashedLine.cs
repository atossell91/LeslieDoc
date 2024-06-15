using System;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public class DashedLine : ILine
    {
        public void DrawLine(XGraphics gfx, XPen pen, XPoint p1, XPoint p2)
        {
            drawComplexLine(gfx, pen, p1, p2, 0.5, 2.0);
        }

        private void drawComplexLine(XGraphics gfx, XPen pen, XPoint mmP1, XPoint mmP2, double mmSep, double mmLen) {
            XPoint p1 = LeslieDoc.PointMillisToPDF(mmP1);
            XPoint p2 = LeslieDoc.PointMillisToPDF(mmP2);

            double xDiff = p2.X - p1.X;
            double yDiff = p2.Y - p1.Y;
            double norm = Math.Sqrt(xDiff*xDiff + yDiff*yDiff);

            double xSep = LeslieDoc.MillisToPdf(mmSep)*xDiff/norm;
            double ySep = LeslieDoc.MillisToPdf(mmSep)*yDiff/norm;
            double xLen = LeslieDoc.MillisToPdf(mmLen)*xDiff/norm;
            double yLen = LeslieDoc.MillisToPdf(mmLen)*yDiff/norm;
            
            double xTot = 0.0;
            double yTot = 0.0;
            XPoint cursor = new XPoint(p1.X, p2.Y);
            while (xTot < Math.Abs(xDiff) && yTot < Math.Abs(yDiff)) {
                XPoint l1 = new XPoint(cursor.X, cursor.Y);
                cursor.X = cursor.X + xLen;
                cursor.Y = cursor.Y + yLen;
                XPoint l2 = new XPoint(cursor.X, cursor.Y);
                gfx.DrawLine(pen, l1, l2);

                cursor.X = cursor.X + xSep;
                cursor.Y = cursor.Y + ySep;

                xTot += Math.Abs(xLen) + Math.Abs(xSep);
                yTot += Math.Abs(yLen) + Math.Abs(ySep);
            }
        }
    }
}