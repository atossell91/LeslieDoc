using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using LeslieDoc;
using LeslieDoc.Lines;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

class Program {
    public static void Main(String[] args) {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        Section docs = new Section();
        ((BorderedCell)docs.Cells["document_date"]).CellContent = new TextElement();

        string jsonStr = File.ReadAllText("./test.json");
        JsonDocument doc = JsonDocument.Parse(jsonStr);
        JsonElement rootElem = doc.RootElement;

        CellFactoryCollection collection = new CellFactoryCollection {
                { "undrawn", new UndrawnCellFactory() },
                { "basic_text", new BasicCellFactory() },
                { "image", new ImageCellFactory() }
        };
        //DocumentJsonParser.InterpretElement(rootElem, collection);
    }
}
