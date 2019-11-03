using MathWorks.MATLAB.NET.Arrays;
using Operations;

namespace MatrixLib
{
    //сложение матриц
    public class Sum : OperationRetMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        //конструктор добавляет матрицы для дальнейшего сложения
        public Sum(Matrix matrixLeft, Matrix matrixRight)
        {
            _matrixLeft = matrixLeft;
            _matrixRight = matrixRight;
        }

        //возвращает или меняет слогаемые
        public Matrix MatrixLeft
        {
            get;
            set;
        }
        public Matrix MatrixRight
        {
            get;
            set;
        }

        //непосредственно считает сумму с использованием библиотеки MatLab
        public Matrix Calculate()
        {
            operationsmatlab op = new operationsmatlab();
            Converter converter = new Converter();
            MWArray[] res = op.Sum(1, converter.ConvertFromMatrixToMLMatrix(_matrixLeft), converter.ConvertFromMatrixToMLMatrix(_matrixRight));
            int[,] resArr = converter.ConvertFromMLMatrixToMatrix(res[0]);
            return new Matrix(_matrixLeft.CountOfRows, _matrixLeft.CountOfColumns, resArr);
        }
    }
}
