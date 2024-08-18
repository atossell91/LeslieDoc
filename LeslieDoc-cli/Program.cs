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
    public static void Main(String[] args) {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        string jsonStr = File.ReadAllText("./test.json");
        JsonDocument doc = JsonDocument.Parse(jsonStr);
        DocumentJsonParser.InterpretFile(doc);
    }
}
