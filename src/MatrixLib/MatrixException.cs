using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MatrixLib.Test")]
[assembly: InternalsVisibleTo("MatrixApp")]

namespace MatrixLib
{
    /// <summary>
    /// Exceptions arising in critical cases of working with Matrix.
    /// </summary>
    internal class MatrixException : Exception
    {
        /// <summary>
        /// Create Exception with message
        /// </summary>
        /// <param name="message">Error message</param>
        public MatrixException(string message) : base(message) { }
    }
}
