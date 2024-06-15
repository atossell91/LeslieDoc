using System;
using System.Collections.Generic;
using System.Linq;
using PdfSharp.Drawing;

namespace LeslieDoc {
    public class Grid
    {
        private delegate IEnumerable<XRect> RectangleGenerator(int upto, XPoint startLoc, XSize sz);


        public static void DrawColumn(XGraphics gfx, int numRows, XSize size, XPoint location, CellStyleInfo styleInfo) {
            drawBlock(gfx, numRows, size, location, styleInfo, rectColGenerator);
        }

        public static void DrawRow(XGraphics gfx, int numRows, XSize size, XPoint location, CellStyleInfo styleInfo) {
            drawBlock(gfx, numRows, size, location, styleInfo, rectRowGenerator);
        }

        private static IEnumerable<XRect> rectColGenerator(int upto, XPoint startLoc, XSize sz) {
            double cellHeight = sz.Height / (double)upto;
            for (int i =0; i < upto; ++i) {
                yield return new XRect(startLoc.X, startLoc.Y + cellHeight * i, sz.Width, cellHeight);
            }
        }

        private static IEnumerable<XRect> rectRowGenerator(int upto, XPoint startLoc, XSize sz) {
            double cellWidth = sz.Width / (double)upto;
            for (int i = 0; i < upto; ++i) {
                yield return new XRect(startLoc.X + cellWidth * i, startLoc.Y, cellWidth, sz.Height);
            }
        }

        private static void drawBlock(XGraphics gfx, int numRows, XSize mmSize, XPoint mmLocation, CellStyleInfo styleInfo, RectangleGenerator rectMaker) {
            
            XSize size = new XSize(
                LeslieDoc.MillisToPdf(mmSize.Width),
                LeslieDoc.MillisToPdf(mmSize.Height)
            );

            XPoint location = new XPoint(
                LeslieDoc.MillisToPdf(mmLocation.X),
                LeslieDoc.MillisToPdf(mmLocation.Y)
            );

            
            if (styleInfo.BackgroundColour != null && !styleInfo.BackgroundColour.IsEmpty) {
                var brush = new XSolidBrush(styleInfo.BackgroundColour);
                gfx.DrawRectangle(brush, location.X, location.Y, size.Width, size.Height);
            }
            
            if (styleInfo.BorderColour != null && !styleInfo.BorderColour.IsEmpty) {
                double width = LeslieDoc.MillisToPdf(styleInfo.BorderWidth);
                XPen pen =new XPen(styleInfo.BorderColour, width);
                gfx.DrawRectangles(pen, rectMaker(numRows, location, size).ToArray());
            }
        }
    }
}
