using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    public class Sum : OperationRetMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        public Matrix GetResult()
        {
            return _matrixLeft;
        }
    }
}
