using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib_0._1
{
    class Converter<MLMatrix,T>
    {
        public MLMatrix ConvertFromMatrixToMLMatrix(Matrix<T> matrix)
        {
            return MLMatrix();
        }

        public Matrix<T> ConvertFromMLMatrixToMatrix(MLMatrix mlMatrix)
        {
            return Matrix();
        }
    }
}
