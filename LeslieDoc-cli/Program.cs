using System;
using System.Drawing;
using LeslieDoc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

class Program {
    public static void Main(String[] args) {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        PdfDocument doc = new PdfDocument();
        var page = doc.AddPage();
        var gfx = XGraphics.FromPdfPage(page);

        var style = new CellStyleInfo() {
            BackgroundColour = XColor.FromKnownColor(XKnownColor.LightGray),
            BorderColour = XColor.FromKnownColor(XKnownColor.Black),
            BorderWidth = 0.2,
        };

        Grid.DrawColumn(gfx, 5, new XSize(30, 100), new XPoint(20, 50), style);
        
        Grid.DrawRow(gfx, 5, new XSize(100, 30), new XPoint(20, 160), style);

        DashedLine line = new DashedLine();
        XPen pen = new XPen(style.BorderColour, 2);
        line.DrawLine(gfx, pen, new XPoint(60, 80), new XPoint(25, 60));
        doc.Save("/home/ant/Programming/LeslieDoc/test.pdf");
    }
}
