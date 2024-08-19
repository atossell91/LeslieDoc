using System;

namespace LeslieDoc {
    public class MissingJsonPropertyException : Exception {
        private static string buildMessage(
            string elementName, string propertName) {

            return String.Format(
                "Element '{0}' requires a property named '{2}'" +
                ", but none is given.", elementName, propertName);    
        }
        public MissingJsonPropertyException(
            string elementName, string propertyName) : 
            base(buildMessage(elementName, propertyName)) {}
    }
}