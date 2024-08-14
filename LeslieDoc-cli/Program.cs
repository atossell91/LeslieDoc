using System;
using System.Drawing;
using LeslieDoc;
using LeslieDoc.Lines;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

class Program {
    public static void Main(String[] args) {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        PdfDocument doc = new PdfDocument();
        var page = doc.AddPage();
        page.Size = PdfSharp.PageSize.Legal;
        var gfx = XGraphics.FromPdfPage(page, XGraphicsUnit.Millimeter);

        BorderedCell nameCell = new BorderedCell();
        nameCell.PositionInfo.Size = new XSize(80, 10);
        nameCell.PositionInfo.Location = new XPoint(20, 10);

        LabelledRectangle nameRect = new LabelledRectangle();
        nameRect.Superscipt.Text = "Person name:";
        nameRect.Content.Text = "Anthony Tossell";
        nameCell.CellContent = nameRect;
        
        BorderedCell ageCell = new BorderedCell();
        ageCell.PositionInfo.Size = new XSize(50, 10);
        ageCell.PositionInfo.Location = new XPoint(
            nameCell.PositionInfo.Right, nameCell.PositionInfo.Top);

        LabelledRectangle ageRect = new LabelledRectangle();
        ageRect.Superscipt.Text = "Age:";
        ageRect.Content.Text = "33";
        ageCell.CellContent = ageRect;
        
        BorderedCell genderCell = new BorderedCell();
        genderCell.PositionInfo.Size = new XSize(60, 10);
        genderCell.PositionInfo.Location = new XPoint(
            ageCell.PositionInfo.Right, ageCell.PositionInfo.Top);

        LabelledRectangle gendeRect = new LabelledRectangle();
        gendeRect.Superscipt.Text = "Gender:";
        gendeRect.Content.Text = "Male";
        genderCell.CellContent = gendeRect;

        BorderedCell typeCell = new BorderedCell();
        typeCell.PositionInfo.Size = new XSize(
            genderCell.PositionInfo.Left - nameCell.PositionInfo.Left, 10);
        typeCell.PositionInfo.Location = new XPoint(
            nameCell.PositionInfo.Left, nameCell.PositionInfo.Bottom);

        LabelledRectangle typeRect = new LabelledRectangle();
        typeRect.Superscipt.Text = "Type of girl to trigger arousal:";
        typeRect.Content.Text = "Plus-sized/Fat";
        typeCell.CellContent = typeRect;

        BorderedCell arousalCell = new BorderedCell();
        arousalCell.PositionInfo.Size = new XSize(
            genderCell.PositionInfo.Right - genderCell.PositionInfo.Left, 10);
        arousalCell.PositionInfo.Location = new XPoint(
            typeCell.PositionInfo.Right, nameCell.PositionInfo.Bottom);

        LabelledRectangle arousalRect = new LabelledRectangle();
        arousalRect.Superscipt.Text = "Preference strength:";
        arousalRect.Content.Text = "Strong";
        arousalCell.CellContent = arousalRect;

        arousalCell.BorderStyle.TopBorderType = LineStyles.StraightLine;
        arousalCell.BorderStyle.BottomBorderType = LineStyles.StraightLine;
        arousalCell.BorderStyle.LeftBorderType = LineStyles.StraightLine;
        arousalCell.BorderStyle.RightBorderType = LineStyles.StraightLine;

        nameCell.BorderStyle.TopBorderType = LineStyles.StraightLine;
        nameCell.BorderStyle.BottomBorderType = LineStyles.StraightLine;
        nameCell.BorderStyle.LeftBorderType = LineStyles.StraightLine;
        nameCell.BorderStyle.RightBorderType = LineStyles.StraightLine;

        ageCell.BorderStyle.TopBorderType = LineStyles.StraightLine;
        ageCell.BorderStyle.BottomBorderType = LineStyles.StraightLine;
        ageCell.BorderStyle.LeftBorderType = LineStyles.StraightLine;
        ageCell.BorderStyle.RightBorderType = LineStyles.StraightLine;

        genderCell.BorderStyle.TopBorderType = LineStyles.StraightLine;
        genderCell.BorderStyle.BottomBorderType = LineStyles.StraightLine;
        genderCell.BorderStyle.LeftBorderType = LineStyles.StraightLine;
        genderCell.BorderStyle.RightBorderType = LineStyles.StraightLine;

        typeCell.BorderStyle.TopBorderType = LineStyles.StraightLine;
        typeCell.BorderStyle.BottomBorderType = LineStyles.StraightLine;
        typeCell.BorderStyle.LeftBorderType = LineStyles.StraightLine;
        typeCell.BorderStyle.RightBorderType = LineStyles.StraightLine;

        nameCell.Draw(gfx);
        ageCell.Draw(gfx);
        genderCell.Draw(gfx);
        typeCell.Draw(gfx);
        arousalCell.Draw(gfx);

        doc.Save("./test.pdf");
    }
}
