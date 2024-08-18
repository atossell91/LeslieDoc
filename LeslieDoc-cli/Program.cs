using System;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using LeslieDoc;
using LeslieDoc.Lines;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

class Program {
    static BorderedCell foo(string subscript, string content,
        double width, double height, double x, double y
    ) {
        BorderedCell cell = new BorderedCell();
        cell.PositionInfo.Size = new XSize(width, height);
        cell.PositionInfo.Location = new XPoint(x, y);

        LabelledRectangle rect = new LabelledRectangle();
        rect.Superscipt.Text = subscript;
        rect.Content.Text = content;
        cell.CellContent = rect;

        cell.BorderStyle.TopBorderType = LineStyles.StraightLine;
        cell.BorderStyle.BottomBorderType = LineStyles.StraightLine;
        cell.BorderStyle.LeftBorderType = LineStyles.StraightLine;
        cell.BorderStyle.RightBorderType = LineStyles.StraightLine;

        return cell;
    }

    public static void Main(String[] args) {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        
        PdfDocument doc = new PdfDocument();
        var page = doc.AddPage();
        page.Size = PdfSharp.PageSize.Legal;
        page.Width = new XUnit(100, XGraphicsUnit.Millimeter);
        page.Height = new XUnit(100, XGraphicsUnit.Millimeter);
        var gfx = XGraphics.FromPdfPage(page, XGraphicsUnit.Millimeter);

        double cellHeight = 11;
        BorderedCell nameCell = foo("Person name:", "Anthony Tossell",
            80, cellHeight, 5, 33);

        var ageCell = foo("Age:", "33",
            15, cellHeight, nameCell.PositionInfo.Right, nameCell.PositionInfo.Top);
        
        var genderCell = foo("Gender:", "Male",
            30, cellHeight, ageCell.PositionInfo.Right, ageCell.PositionInfo.Top);

        var typeCell = foo("Type of girl to trigger arousal", "Plus-sized/Fat",
            ageCell.PositionInfo.Right - nameCell.PositionInfo.Left, cellHeight, nameCell.PositionInfo.Left, nameCell.PositionInfo.Bottom);

        var arousalCell = foo("Preference Strength:", "Strong",
            genderCell.PositionInfo.Right - typeCell.PositionInfo.Right, cellHeight, typeCell.PositionInfo.Right, typeCell.PositionInfo.Top);

        BorderedCell imgCell = new BorderedCell();
        BoundImage bimg = new BoundImage();
        bimg.Image = XImage.FromFile("/home/ant/joscelyn.png");
        imgCell.CellContent = bimg;
        imgCell.PositionInfo.Location = new XPoint(typeCell.PositionInfo.Left, typeCell.PositionInfo.Bottom);
        imgCell.PositionInfo.Size = new XSize(typeCell.PositionInfo.Size.Width, cellHeight);

        nameCell.Draw(gfx);
        ageCell.Draw(gfx);
        genderCell.Draw(gfx);
        typeCell.Draw(gfx);
        arousalCell.Draw(gfx);
        imgCell.Draw(gfx);

        doc.Save("./test.pdf");
    }
}
