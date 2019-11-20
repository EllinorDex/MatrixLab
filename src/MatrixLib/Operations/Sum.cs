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
            OperWithMatr op     = new OperWithMatr();
            Converter<T> converter = new Converter<T>();

            MWArray[] result = op.Sum(1, converter.ConvertFromMatrixToMLMatrix(_matrixLeft), converter.ConvertFromMatrixToMLMatrix(_matrixRight));
            T[,] resultArr = converter.ConvertFromMLMatrixToMatrix(result[0]);

            return new Matrix<T>(_matrixLeft.GetCountOfRows(), _matrixLeft.GetCountOfColumns(), resultArr);
        }

        //Проверка корректности операции
        private void IsCorrect(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            if (matrixLeft.GetCountOfRows() != matrixRight.GetCountOfRows() || matrixLeft.GetCountOfColumns() != matrixRight.GetCountOfColumns())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operands.");
        }
    }
}
