using MathWorks.MATLAB.NET.Arrays;
using Operations;

namespace MatrixLib
{
    //Операция умножения матриц
    public class Multiplication : OperationThatReturnMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        //Конструктор, в котором происходит формирование операндов
        public Multiplication(Matrix matrixLeft, Matrix matrixRight)
        {
            _matrixLeft  = matrixLeft;
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

        //Подсчёт произведения
        public Matrix Calculate()
        {
            isCorrect(_matrixLeft, _matrixRight);
            OperWithMatr op     = new OperWithMatr();
            Converter converter = new Converter();

            MWArray[] result = op.Multiplication(1, converter.ConvertFromMatrixToMLMatrix(_matrixLeft), converter.ConvertFromMatrixToMLMatrix(_matrixRight));
            int[,] resultArr = converter.ConvertFromMLMatrixToMatrix(result[0]);

            return new Matrix(_matrixLeft.GetCountOfRows(), _matrixRight.GetCountOfColumns(), resultArr);
        }

        //Проверка корректности операции
        private void isCorrect(Matrix matrixLeft, Matrix matrixRight)
        {
            if (matrixLeft.GetCountOfColumns() != matrixRight.GetCountOfRows())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operands.");
        }
    }
}
