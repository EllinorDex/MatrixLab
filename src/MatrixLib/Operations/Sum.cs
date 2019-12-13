using MathWorks.MATLAB.NET.Arrays;
using Operations;
using System;

namespace MatrixLib
{
    //Операция сложения матриц
    public class Sum<T> : IOperationThatReturnMatrix<T> where T: IConvertible
    {
        private Matrix<T> _matrixLeft;
        private Matrix<T> _matrixRight;

        //Конструктор, в котором происходит формирование операндов
        public Sum(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            _matrixLeft = matrixLeft;
            _matrixRight = matrixRight;
        }

        //Получение или изменение левого операнда
        public Matrix<T> MatrixLeft
        {
            get { return _matrixLeft; }
            set { _matrixLeft = value; }
        }

        //Получение или изменение правого операнда
        public Matrix<T> MatrixRight
        {
            get { return _matrixRight; }
            set { _matrixRight = value; }
        }

        //Подсчёт суммы
        public Matrix<T> Calculate()
        {
            IsCorrect(_matrixLeft, _matrixRight);
            var op     = new OperWithMatr();
            var converter = new Converter<T>();

            var result = op.Sum(1, converter.ConvertFromMatrixToMlMatrix(_matrixLeft), converter.ConvertFromMatrixToMlMatrix(_matrixRight));
            var resultArr = converter.ConvertFromMlMatrixToMatrix(result[0]);

            return new Matrix<T>(_matrixLeft.CountOfRows, _matrixLeft.CountOfColumns, resultArr);
        }

        //Проверка корректности операции
        private void IsCorrect(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            if (matrixLeft.CountOfRows != matrixRight.CountOfRows || matrixLeft.CountOfColumns != matrixRight.CountOfColumns)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operands.");
        }
    }
}
