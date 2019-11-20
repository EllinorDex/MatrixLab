using MathWorks.MATLAB.NET.Arrays;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MatrixTest")]

namespace MatrixLib
{
    //Конвертация C# <-> MATLAB
    internal class Converter<T> where T: IConvertible
    {
        //Конвертация из матрицы в встроенный тип MatLab
        public MWArray ConvertFromMatrixToMLMatrix(Matrix<T> matrix)
        {
            MWNumericArray mwnArr = new MWNumericArray((Array)matrix.Get2DArray());
            return (MWArray)mwnArr;
        }

        //Конвертация из встроенного типа MatLab в матрицу
        public T[,] ConvertFromMLMatrixToMatrix(MWArray mwMatrix)
        {
            double[,] matrix = (double[,])mwMatrix.ToArray();
            int length1      = matrix.GetLength(0);
            int length2      = matrix.GetLength(1);

            T[,] res = new T[length1, length2];
            for (int i = 0; i < length1; ++i)
                for (int j = 0; j < length2; ++j)
                    res[i, j] = (T)Convert.ChangeType(Math.Round(matrix[i, j], 3),typeof(T));
            return res;
        }

        //Конвертация из встроенного типа MatLab в скаляр
        public T ConvertFromMLMatrixToScalar(MWArray mwMatrix)
        {
            double[,] matrix = (double[,])mwMatrix.ToArray();
            T res            = (T)Convert.ChangeType(Math.Round(matrix[0, 0], 3), typeof(T));

            return res;
        }
    }
}
