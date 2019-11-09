using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MatrixTest")]

namespace MatrixLib
{
    //Исключение, соответсвующее критическим ситуациям работы с матрицами
    internal class MatrixException : Exception
    {
        public MatrixException() { }

        public MatrixException(string message) : base(message) { }

        public MatrixException(string message, Exception inner) : base(message, inner) { }

        protected MatrixException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
