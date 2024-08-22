using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace LeslieDoc {
    public class DocumentJsonParser {
        const int MaxDepth = 100;
        public static bool IsNumber(string value) {
            var match = Regex.Match(value, @"\d+(\.\d+)?(mm)?");
            return match.Success;
        }

        public static double ParseSizeValue(string value) 
        {
            var match = Regex.Match(value, @"\d+(\.\d+)");
            return Double.Parse(match.Value);
        }

        public static bool IsCell(string value) {
            var match = Regex.Match(value, @"[a-zA-Z_0-9](.[a-zA-Z_0-9])");
            return match.Success;
        }

        public static CellReference ParseCellReference(string value) {
            string[] tokens = value.Split('.');
            string cellName = tokens[0];
            string cellProperty = string.Empty;
            if (tokens.Length > 1) {
                cellProperty = tokens[1];
            }

            return new CellReference {
                CellName = cellName,
                CellProperty = cellProperty
            };
        }

        public static string GetCellReferenceValue(JsonElement elem, string val) {
            var cellReference = ParseCellReference(val);
            return GetCellReferenceValue(elem, cellReference.CellName, cellReference.CellProperty, 0);
        }

        private static string GetCellReferenceValue(JsonElement elem, string cellName, string cellProperty, int depth) {
            if (depth >= MaxDepth) {
                throw new RecursionDepthLimitException("I love Lorraine!");
            }

            string val = String.Empty;
            if (String.IsNullOrEmpty(cellProperty)) {
                val = elem.GetProperty(cellName).ToString();
            }
            else {
                val = elem.GetProperty(cellName).GetProperty(cellProperty).ToString();
            }

            JsonElement fakeElem;
            CellReference cref = ParseCellReference(val);
            if (IsCell(val) && elem.TryGetProperty(cref.CellName, out fakeElem)) {
                return GetCellReferenceValue(elem, cref.CellName, cref.CellProperty, depth+1);
            }
            else {
                return val;
            }
        }

        public static NumericResult ParseSizeValue(JsonElement json, string valueName) {
            /*
                -- Pseudocode --
                ValueStr = LookupJsonValue(ValueName)
                If ValueStr != None
                    If IsNumber(ValueStr)
                        NumericResult = ParseSizeValue(ValueStr)
                    ElseIf IsCell(ValueStr)
                        // The following function would need reflection
                        //  is there a better way?
                        NumericResult = GetCellReferenceValue(ValueStr)
                    Else
                        NumericResult = Result.FailedResult("Width provided, but it's type couldn't be determined")
                return NumericResult
            */
            NumericResult numericResult= new NumericResult();

            string valueStr = String.Empty;
            try {
                valueStr = json.GetProperty(valueName).GetString();
            }
            catch(Exception) {
                numericResult.Result = Result.Fail;
                return numericResult;
            }

            if (!string.IsNullOrEmpty(valueStr)) 
            {
                if (IsNumber(valueStr)) {
                    double num = ParseSizeValue(valueStr);
                    numericResult.Result = Result.Success;
                    numericResult.Value = num;
                }
                else if (IsCell(valueStr)) {
                    // What happens if the value doesn't exist and/or the parse fails?
                    string value = GetCellReferenceValue(json, valueStr);
                    double num = ParseSizeValue(value);
                    numericResult.Result = Result.Success;
                    numericResult.Value = num;
                }
                else {
                    numericResult.Result = Result.Fail;
                }
            }
            else {
                numericResult.Result = Result.Fail;
            }

            return numericResult;
        }

        public static string InferValue(NumericResult highValue, NumericResult lowValue) {
            /*
                -- Pseudocode --
                If HighValueResult.Result != Result.Success || LowValueResult.Result != Result.Success
                    NumericResult = Result.FailedResult("If width is empty, valid left and right values must be provided")
                Else
                    NumericResult = FitCellValue(HighValueResult.Value, LowValueResult.Value)

                return NumericResult
            */
            throw new NotImplementedException();
        }

        public static NumericResult ParseWidth(JsonElement json) {
            /*
                -- Pseudocode
                NumericResult = ParseSizeValue(json, "width");
                if NumericResult.Result == Result.Success
                    return NumericResult
                else
                    return InferValue()
            */
            throw new NotImplementedException();
        }

        public static NumericResult ParseHeight(JsonElement json) {
            /*
                -- Pseudocode
                NumericResult = ParseSizeValue(json, "height");
                if NumericResult.Result == Result.Success
                    return NumericResult
                else
                    return InferValue()
            */
            throw new NotImplementedException();
        }

        public static CellCollection ParseCellCollection(string name, JsonElement element,
        CellFactoryCollection factories) {
            throw new NotImplementedException();
        }
        public static ICell ParseSingleCell(string name, JsonElement element,
        CellFactoryCollection factories) {
            throw new NotImplementedException();
        }

        public static string GetElementStringProperty(JsonElement element, string name) {
            JsonElement innerElem;
            if (element.TryGetProperty(name, out innerElem)) {
                return innerElem.GetString();
            }
            else {
                return String.Empty;
            }
        }

        public static bool TryExtractString(JsonElement element, string key, out string value) {
            JsonElement tempElement;
            value = null;
            if (element.TryGetProperty(key, out tempElement)) {
                value = tempElement.GetRawText();
                return true;
            }
            else {
                return false;
            }
        }

        public static bool TryExtractInt(JsonElement element, string key, out int value) {
            JsonElement tempElement;
            value = 0;
            if (element.TryGetProperty(key, out tempElement)) {
                int tempInt;
                if (tempElement.TryGetInt32(out tempInt)) {
                    value = tempInt;
                    return true;
                }
            }

            return false;
        }

        public static Section Emily(JsonElement element, CellFactoryCollection factories) {
            Section p = new Section();
            ICell c = p.CellGroups["outerGroup"][0];
            foreach (JsonProperty jsonProperty in element.EnumerateObject()) {
                string name = jsonProperty.Name;
                JsonElement currentElement = jsonProperty.Value;
                int repeats;
                if (TryExtractInt(currentElement, "num_repeats", out repeats)) {
                    JsonElement subElement;
                    if (currentElement.TryGetProperty("cells", out subElement)) {
                        Section pkg = Emily(subElement, factories);
                        p.Cells.ConcatCollection(pkg.Cells);
                        
                    }
                }
                else {
                    string cellType;
                    if (TryExtractString(currentElement, "cell_type", out cellType)) {
                        ICell cell = factories[cellType].CreateCell(currentElement);
                        p.Cells.Add(name, cell);
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}