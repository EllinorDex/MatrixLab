using System;
using System.Collections.Generic;
<<<<<<< HEAD
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
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    class MLMatrix
    {

    }
    internal class Converter<T>
    {
        public MLMatrix ConvertFromMatrixToMLMatrix(Matrix<T> matrix)
        {
            return new MLMatrix();
        }

        public Matrix<T> ConvertFromMLMatrixToMatrix(MLMatrix mlMatrix)
        {
            return new Matrix<T>(0,0,"");
        }
    }

>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
}
