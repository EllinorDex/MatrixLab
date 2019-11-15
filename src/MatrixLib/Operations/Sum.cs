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
            _matrixLeft = matrixLeft;
            _matrixRight = matrixRight;
        }

        //Получение или изменение левого операнда
        public Matrix MatrixLeft
        {
            get { return _matrixLeft; }
            set { _matrixLeft = value; }
        }

        //Получение или изменение правого операнда
        public Matrix MatrixRight
        {
            get { return _matrixRight; }
            set { _matrixRight = value; }
        }

        //Подсчёт суммы
        public Matrix Calculate()
        {
            isCorrect(_matrixLeft, _matrixRight);
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
