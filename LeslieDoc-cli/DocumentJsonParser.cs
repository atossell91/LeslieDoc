using System;
using System.Text.Json;

namespace LeslieDoc {
    public class DocumentJsonParser {
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
            throw new NotImplementedException();
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