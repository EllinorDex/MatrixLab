using MathWorks.MATLAB.NET.Arrays;
using Operations;
using System;

namespace MatrixLib
{
    //Операция нахождения определителя матрицы
    public class Determinant<T> : IOperationThatReturnScalar<T> where T : IConvertible
    {
        private Matrix<T> _matrixOperand;

        //Конструктор, в котором происходит формирование операнда
        public Determinant(Matrix<T> matrixOperand)
        {
            _matrixOperand = matrixOperand;
        }

        //Получение или изменение операнда
        public Matrix<T> MatrixOperand
        {
            get { return _matrixOperand; }
            set { _matrixOperand = value; }
        }

        //Подсчёт определителя
        public T Calculate()
        {
            IsCorrect(_matrixOperand);
            var op        = new OperWithMatr();
            var converter = new Converter<T>();

            var result = op.Determinant(1, converter.ConvertFromMatrixToMlMatrix(_matrixOperand));
            var resultScal   = converter.ConvertFromMlMatrixToScalar(result[0]);

            return resultScal;
        }

        //Проверка корректности операции
        private void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.CountOfColumns != matrixOperand.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
        }
    }
}