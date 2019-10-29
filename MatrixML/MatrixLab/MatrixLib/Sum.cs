using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Arrays;
using Operations;

namespace MatrixLib
{
    public class Sum : OperationRetMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        public Matrix MatrixLeft
        {
            get { return _matrixLeft; }
            set { _matrixLeft = value; }
        }

        public Matrix MatrixRight
        {
            get { return _matrixRight; }
            set { _matrixRight = value; }
        }

        public Matrix GetResult()
        {
            operationsmatlab op = new operationsmatlab();
            Converter converter = new Converter();
            MWArray[] res = op.Sum(1, converter.ConvertFromMatrixToMLMatrix(_matrixLeft), converter.ConvertFromMatrixToMLMatrix(_matrixRight));
            int[,] resArr = converter.ConvertFromMLMatrixToMatrix(res[0]);
            return new Matrix(_matrixLeft.CountOfRows, _matrixLeft.CountOfColumns, resArr);
        }
    }
}
