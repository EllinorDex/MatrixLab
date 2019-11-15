using MathWorks.MATLAB.NET.Arrays;
using Operations;

namespace MatrixLib
{
    //Операция нахождения обратной матрицы
    public class InverseMatrix : OperationThatReturnMatrix
    {
        private Matrix _matrixOperand;

        //Конструктор, в котором происходит формирование операнда
        public InverseMatrix(Matrix matrixOperand)
        {
            _matrixOperand = matrixOperand;
        }

        //Получение или изменение операнда
        public Matrix MatrixOperand
        {
            get { return _matrixOperand; }
            set { _matrixOperand = value; }
        }

        //Нахождение обратной матрицы
        public Matrix Calculate()
        {
            isCorrect(_matrixOperand);
            OperWithMatr op     = new OperWithMatr();
            Converter converter = new Converter();

            MWArray[] result = op.InverseMatrix(1, converter.ConvertFromMatrixToMLMatrix(_matrixOperand));
            int[,] resultArr = converter.ConvertFromMLMatrixToMatrix(result[0]);

            return new Matrix(_matrixOperand.GetCountOfRows(), _matrixOperand.GetCountOfColumns(), resultArr);
        }

        //Проверка корректности операции
        private void isCorrect(Matrix matrixOperand)
        {
            if (matrixOperand.GetCountOfColumns() != matrixOperand.GetCountOfRows())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
            Determinant det = new Determinant(matrixOperand);
            if (det.Calculate() == 0)
                throw new MatrixException("The operation cannot be performed. Incorrect matrix.");
        }
    }
}