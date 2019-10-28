using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    public class InverseMatrix : OperationRetMatrix
    {
        private Matrix _matrix;

        public Matrix GetResult()
        {
            return _matrix;
        }
    }
}
