using MathWorks.MATLAB.NET.Arrays;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MatrixTest")]

namespace MatrixLib
{
    //Convert C# <-> MATLAB
    internal static class Converter<T> where T: IConvertible
    {
        //Конвертация из матрицы в встроенный тип MatLab
        public static MWArray ConvertFromMatrixToMlMatrix(Matrix<T> matrix)
        {
            var mwnArr = new MWNumericArray((Array)matrix.Get2DArray());
            return (MWArray)mwnArr;
        }

        //Конвертация из встроенного типа MatLab в матрицу
        public static T[,] ConvertFromMlMatrixToMatrix(MWArray mwMatrix)
        {
            var matrix = (double[,])mwMatrix.ToArray();
            var length1      = matrix.GetLength(0);
            var length2      = matrix.GetLength(1);

            var res = new T[length1, length2];
            for (var i = 0; i < length1; ++i)
                for (var j = 0; j < length2; ++j)
                    res[i, j] = (T)Convert.ChangeType(Math.Round(matrix[i, j], 3),typeof(T));
            return res;
        }

        //Конвертация из встроенного типа MatLab в скаляр
        public static T ConvertFromMlMatrixToScalar(MWArray mwMatrix)
        {
            var matrix = (double[,])mwMatrix.ToArray();
            var res            = (T)Convert.ChangeType(Math.Round(matrix[0, 0], 3), typeof(T));

            return res;
        }
    }
}
