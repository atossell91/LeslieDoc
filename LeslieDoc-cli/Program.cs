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
        page.Size = PdfSharp.PageSize.Legal;
        var gfx = XGraphics.FromPdfPage(page);

        var style = new CellStyleInfo() {
            BackgroundColour = XColor.FromKnownColor(XKnownColor.LightGray),
            BorderColour = XColor.FromKnownColor(XKnownColor.Black),
            BorderWidth = 0.2,
        };

        var pos = Grid.DrawColumn(gfx, 5, new XSize(30, 100), new XPoint(20, 50), style);

        Cell myCell = new Cell();
        myCell.Location = new XPoint(20, 20);
        myCell.Size = new XSize(15, 6);
        myCell.BackgroundColor = XBrushes.HotPink.Color;
        
        myCell.LeftBorder = LeslieDoc.Lines.LineStyles.DashedLine;
        myCell.RightBorder = LeslieDoc.Lines.LineStyles.DashedLine;
        myCell.TopBorder = LeslieDoc.Lines.LineStyles.StraightLine;
        myCell.BottomBorder = LeslieDoc.Lines.LineStyles.StraightLine;

        for (int y = 0; y < 4; ++y)
        {
            for (int x = 0; x < 10; ++x)
            {
                myCell.Location = new XPoint(
                    myCell.Size.Width * x,
                    myCell.Size.Height * y
                    );

                myCell.Draw(gfx);
            }
        }
        myCell.Draw(gfx);

        doc.Save("./test.pdf");
    }
}
