using System;

namespace MatrixLib
{
    //Исключение, соответсвующее критическим ситуациям работы с матрицами
    public class MatrixException : Exception
    {
        public MatrixException() { }

        public MatrixException(string message) : base(message) { }

        public MatrixException(string message, Exception inner) : base(message, inner) { }

        protected MatrixException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
