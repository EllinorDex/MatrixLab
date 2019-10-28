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
            MWArray[] mwArr = new MWArray(matrix);
            return new MWArray();
        }

        public Matrix ConvertFromMLMatrixToMatrix(MWArray mwMatrix)
        {
            return new Matrix(0, 0, "");
        }
     }
}
