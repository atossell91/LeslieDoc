using System;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public class LeslieDoc
    {
        public const double unitPerMillimeter = 360.0/127.0;

        public static double MillisToPdf(double millimeter) {
            return millimeter*unitPerMillimeter;
        }

        public static XPoint PointMillisToPDF(XPoint point) {
            return new XPoint() {
                X = MillisToPdf(point.X),
                Y = MillisToPdf(point.Y)
            };
        }
    }
}
