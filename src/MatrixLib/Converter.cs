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
            MWNumericArray mwArr = new MWNumericArray((Array)matrix.GetMatrix());
            return (MWArray)mwArr;
        }

        //конвертация из MatLab
        public int[,] ConvertFromMLMatrixToMatrix(MWArray mwMatrix)
        {
            int[,] matrix = (int[,])mwMatrix.ToArray();
            return matrix;
        }
    }
}
