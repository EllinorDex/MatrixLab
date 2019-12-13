using MathWorks.MATLAB.NET.Arrays;
using Operations;
using System;

namespace MatrixLib
{
    //Операция нахождения обратной матрицы
    public class InverseMatrix<T> : IOperationThatReturnMatrix<T> where T: IConvertible
    {
        private Matrix<T> _matrixOperand;

        //Конструктор, в котором происходит формирование операнда
        public InverseMatrix(Matrix<T> matrixOperand)
        {
            _matrixOperand = matrixOperand;
        }

        //Получение или изменение операнда
        public Matrix<T> MatrixOperand
        {
            get { return _matrixOperand; }
            set { _matrixOperand = value; }
        }

        //Нахождение обратной матрицы
        public Matrix<T> Calculate()
        {
            IsCorrect(_matrixOperand);
            var op     = new OperWithMatr();
            var converter = new Converter<T>();

            var result = op.InverseMatrix(1, converter.ConvertFromMatrixToMlMatrix(_matrixOperand));
            var resultArr = converter.ConvertFromMlMatrixToMatrix(result[0]);

            return new Matrix<T>(_matrixOperand.CountOfRows, _matrixOperand.CountOfColumns, resultArr);
        }

        //Проверка корректности операции
        private void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.CountOfColumns != matrixOperand.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
            var det = new Determinant<T>(matrixOperand);
            if ((double)Convert.ChangeType(det.Calculate(),typeof(double)) == (double)Convert.ChangeType(default(T),typeof(double)));
                throw new MatrixException("The operation cannot be performed. Incorrect matrix.");
        }
    }
}