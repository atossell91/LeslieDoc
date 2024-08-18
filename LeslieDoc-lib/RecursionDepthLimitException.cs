using System;

namespace LeslieDoc {
    public class RecursionDepthLimitException : Exception {
        public RecursionDepthLimitException(string ms) : base(ms) { }
    }
}