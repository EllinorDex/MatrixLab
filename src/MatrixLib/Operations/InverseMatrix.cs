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
            OperWithMatr op     = new OperWithMatr();
            Converter<T> converter = new Converter<T>();

            MWArray[] result = op.InverseMatrix(1, converter.ConvertFromMatrixToMLMatrix(_matrixOperand));
            T[,] resultArr = converter.ConvertFromMLMatrixToMatrix(result[0]);

            return new Matrix<T>(_matrixOperand.GetCountOfRows(), _matrixOperand.GetCountOfColumns(), resultArr);
        }

        //Проверка корректности операции
        private void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.GetCountOfColumns() != matrixOperand.GetCountOfRows())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
            Determinant<T> det = new Determinant<T>(matrixOperand);
            if ((int)Convert.ChangeType(det.Calculate(),typeof(int)) == (int)Convert.ChangeType(default(T),typeof(int)))
                throw new MatrixException("The operation cannot be performed. Incorrect matrix.");
        }
    }
}