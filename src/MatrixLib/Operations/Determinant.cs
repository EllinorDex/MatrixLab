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
            OperWithMatr op        = new OperWithMatr();
            Converter<T> converter = new Converter<T>();

            MWArray[] result = op.Determinant(1, converter.ConvertFromMatrixToMLMatrix(_matrixOperand));
            T resultScal   = converter.ConvertFromMLMatrixToScalar(result[0]);

            return resultScal;
        }

        //Проверка корректности операции
        private void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.GetCountOfColumns() != matrixOperand.GetCountOfRows())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
        }
    }
}