using MathWorks.MATLAB.NET.Arrays;
using Operations;

namespace MatrixLib
{
    //Операция сложения матриц
    public class Sum : OperationThatReturnMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        //Конструктор, в котором происходит формирование операндов
        public Sum(Matrix matrixLeft, Matrix matrixRight)
        {
            isCorrect(matrixLeft, matrixRight);
            _matrixLeft = matrixLeft;
            _matrixRight = matrixRight;
        }

        //Получение или изменение левого операнда
        public Matrix MatrixLeft
        {
            get;
            set;
        }

        //Получение или изменение правого операнда
        public Matrix MatrixRight
        {
            get;
            set;
        }

        //Подсчёт суммы
        public Matrix Calculate()
        {
            OperWithMatr op     = new OperWithMatr();
            Converter converter = new Converter();

            MWArray[] result = op.Sum(1, converter.ConvertFromMatrixToMLMatrix(_matrixLeft), converter.ConvertFromMatrixToMLMatrix(_matrixRight));
            int[,] resultArr = converter.ConvertFromMLMatrixToMatrix(result[0]);

            return new Matrix(_matrixLeft.GetCountOfRows(), _matrixLeft.GetCountOfColumns(), resultArr);
        }

        //Проверка корректности операции
        private void isCorrect(Matrix matrixLeft, Matrix matrixRight)
        {
            if (matrixLeft.GetCountOfRows() != matrixRight.GetCountOfRows() || matrixLeft.GetCountOfColumns() != matrixRight.GetCountOfColumns())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operands.");
        }
    }
}
