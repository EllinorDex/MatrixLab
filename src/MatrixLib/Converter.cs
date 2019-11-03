using MathWorks.MATLAB.NET.Arrays;
using System;

namespace MatrixLib
{
    //конвертирует типы C# <-> MATLAB
    internal class Converter
    {
        //конвертация в MatLab
        public MWArray ConvertFromMatrixToMLMatrix(Matrix matrix)
        {
            MWNumericArray mwArr = new MWNumericArray((Array)matrix.Get2DArray());
            return (MWArray)mwArr;
        }

        //конвертация из MatLab
        public int[,] ConvertFromMLMatrixToMatrix(MWArray mwMatrix)
        {
            double[,] matrix = (double[,])mwMatrix.ToArray();
            int length1 = matrix.GetLength(0);
            int length2 = matrix.GetLength(1);
            int[,] res = new int[length1, length2];

            for (int i = 0; i < length1; ++i)
                for (int j = 0; j < length2; ++j)
                    res[i, j] = (int)matrix[i, j];
            return res;
        }
    }
}
