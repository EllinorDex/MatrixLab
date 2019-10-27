using System;
using System.Collections.Generic;
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

}
