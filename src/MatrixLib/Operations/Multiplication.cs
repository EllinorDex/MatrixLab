using MathWorks.MATLAB.NET.Arrays;
using Operations;
using System;

namespace MatrixLib
{
    //Операция умножения матриц
    public class Multiplication<T> : IOperationThatReturnMatrix<T> where T: IConvertible
    {
        //Конструктор, в котором происходит формирование операндов
        public Multiplication(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            MatrixLeft  = matrixLeft;
            MatrixRight = matrixRight;
        }

        //Получение или изменение левого операнда
        public Matrix<T> MatrixLeft { get; set; }

        //Получение или изменение правого операнда
        public Matrix<T> MatrixRight { get; set; }

        //Подсчёт произведения
        public Matrix<T> Calculate()
        {
            IsCorrect(MatrixLeft, MatrixRight);
            var op     = new OperWithMatr();

            var result = op.Multiplication(1, Converter<T>.ConvertFromMatrixToMlMatrix(MatrixLeft), Converter<T>.ConvertFromMatrixToMlMatrix(MatrixRight));
            var resultArr = Converter<T>.ConvertFromMlMatrixToMatrix(result[0]);

            return new Matrix<T>(MatrixLeft.CountOfRows, MatrixRight.CountOfColumns, resultArr);
        }

        //Проверка корректности операции
        private static void IsCorrect(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            if (matrixLeft.CountOfColumns != matrixRight.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operands.");
        }
    }
}
