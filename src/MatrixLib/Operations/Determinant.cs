using MathWorks.MATLAB.NET.Arrays;
using Operations;
using System;

namespace MatrixLib
{
    //Операция нахождения определителя матрицы
    public class Determinant<T> : IOperationThatReturnScalar<T> where T : IConvertible
    {
        //Конструктор, в котором происходит формирование операнда
        public Determinant(Matrix<T> matrixOperand)
        {
            MatrixOperand = matrixOperand;
        }

        //Получение или изменение операнда
        public Matrix<T> MatrixOperand { get; set; }

        //Подсчёт определителя
        public T Calculate()
        {
            IsCorrect(MatrixOperand);
            var op        = new OperWithMatr();

            var result = op.Determinant(1, Converter<T>.ConvertFromMatrixToMlMatrix(MatrixOperand));
            var resultScal   = Converter<T>.ConvertFromMlMatrixToScalar(result[0]);

            return resultScal;
        }

        //Проверка корректности операции
        private static void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.CountOfColumns != matrixOperand.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
        }
    }
}