using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    public class Multiplication : OperationRetMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        public Matrix GetResult()
        {
            return _matrixLeft;
        }
    }
}
