using System;
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
    }
}