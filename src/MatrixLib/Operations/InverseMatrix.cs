using MathWorks.MATLAB.NET.Arrays;
using Operations;
using System;

namespace MatrixLib
{
    //Операция нахождения обратной матрицы
    public class InverseMatrix<T> : IOperationThatReturnMatrix<T> where T: IConvertible
    {
        //Конструктор, в котором происходит формирование операнда
        public InverseMatrix(Matrix<T> matrixOperand)
        {
            MatrixOperand = matrixOperand;
        }

        //Получение или изменение операнда
        public Matrix<T> MatrixOperand { get; set; }

        //Нахождение обратной матрицы
        public Matrix<T> Calculate()
        {
            IsCorrect(MatrixOperand);
            var op     = new OperWithMatr();

            var result = op.InverseMatrix(1, Converter<T>.ConvertFromMatrixToMlMatrix(MatrixOperand));
            var resultArr = Converter<T>.ConvertFromMlMatrixToMatrix(result[0]);

            return new Matrix<T>(MatrixOperand.CountOfRows, MatrixOperand.CountOfColumns, resultArr);
        }

        //Проверка корректности операции
        private static void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.CountOfColumns != matrixOperand.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
            var det = new Determinant<T>(matrixOperand);
            if (Math.Abs((double)Convert.ChangeType(det.Calculate(),typeof(double)) - (double)0) < 1e-3)
                throw new MatrixException("The operation cannot be performed. Incorrect matrix.");
        }
    }
}