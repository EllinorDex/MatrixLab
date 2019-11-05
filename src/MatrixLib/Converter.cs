using MathWorks.MATLAB.NET.Arrays;
using System;

namespace MatrixLib
{
    //Конвертация C# <-> MATLAB
    internal class Converter
    {
        //Конвертация из матрицы в встроенный тип MatLab
        public MWArray ConvertFromMatrixToMLMatrix(Matrix matrix)
        {
            MWNumericArray mwArr = new MWNumericArray((Array)matrix.Get2DArray());
            return (MWArray)mwArr;
        }

        //Конвертация из встроенного типа MatLab в матрицу
        public int[,] ConvertFromMLMatrixToMatrix(MWArray mwMatrix)
        {
            double[,] matrix = (double[,])mwMatrix.ToArray();
            int length1      = matrix.GetLength(0);
            int length2      = matrix.GetLength(1);
            int[,] res       = new int[length1, length2];

            for (int i = 0; i < length1; ++i)
                for (int j = 0; j < length2; ++j)
                    res[i, j] = (int)matrix[i, j];
            return res;
        }

        //Конвертация из встроенного типа MatLab в скаляр
        public int ConvertFromMLMatrixToScalar(MWArray mwMatrix)
        {
            //Что-то в этой строчке не так. Посмотри, из-за неё возникает исключение: "Заданное приведение является недопустимым"
            int res = (int)mwMatrix.ToArray().GetValue(0,0);

            return res;
        }
    }
}
