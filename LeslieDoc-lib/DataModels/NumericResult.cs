namespace LeslieDoc {
    public enum Result {
        Success,
        Fail
    }

    public class NumericResult {
        public Result Result { get; set; }
        public double Value { get; set; }
    }
}