using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MatrixTest")]
[assembly: InternalsVisibleTo("MatrixApp")]

namespace MatrixLib
{
    //Exception
    internal class MatrixException : Exception
    {
        public MatrixException(string message) : base(message) { }
    }
}
