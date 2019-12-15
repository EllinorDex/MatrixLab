using MathWorks.MATLAB.NET.Arrays;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MatrixLib.Test")]

namespace MatrixLib
{
    /// <summary>
    /// Converter C# <=> MatLab
    /// </summary>
    /// <typeparam name="T">Type of values.</typeparam>
    internal static class Converter<T> where T : IConvertible
    {
        /// <summary>
        /// Convert from Matrix to built-in type MatLab
        /// </summary>
        /// <param name="matrix">matrix</param>
        /// <returns>MWArray - built-in type MatLab</returns>
        public static MWArray ConvertFromMatrixToMlMatrix(Matrix<T> matrix)
        {
            var mwnArr = new MWNumericArray(matrix.Get2DArray());
            return mwnArr;
        }

        /// <summary>
        /// Convert from the built-in type MatLab to the Matrix
        /// </summary>
        /// <param name="mwMatrix">MWArray - built-in type MatLab</param>
        /// <returns>Matrix</returns>
        public static T[,] ConvertFromMlMatrixToMatrix(MWArray mwMatrix)
        {
            var matrix = (double[,])mwMatrix.ToArray();
            var length1 = matrix.GetLength(0);
            var length2 = matrix.GetLength(1);

            var res = new T[length1, length2];
            for (var i = 0; i < length1; ++i)
                for (var j = 0; j < length2; ++j)
                    res[i, j] = (T)Convert.ChangeType(Math.Round(matrix[i, j], 3), typeof(T));
            return res;
        }

        /// <summary>
        /// Convert from the built-in MatLab type to a scalar value
        /// </summary>
        /// <param name="mwMatrix">MWArray - built-in type MatLab</param>
        /// <returns>Scalar value</returns>
        public static T ConvertFromMlMatrixToScalar(MWArray mwMatrix)
        {
            var matrix = (double[,])mwMatrix.ToArray();
            var res = (T)Convert.ChangeType(Math.Round(matrix[0, 0], 3), typeof(T));

            return res;
        }
    }
}
