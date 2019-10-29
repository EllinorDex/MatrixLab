using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace MatrixLib
{
    internal class Converter
    {
        public MWArray ConvertFromMatrixToMLMatrix(Matrix matrix)
        {
            MWNumericArray mwArr = new MWNumericArray((Array)matrix.GetMatrix());
            return (MWArray)mwArr;
        }

        public int[,] ConvertFromMLMatrixToMatrix(MWArray mwMatrix)
        {
            int[,] matrix = (int[,])mwMatrix.ToArray();
            return matrix;
        }
    }
}
