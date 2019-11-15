using MathWorks.MATLAB.NET.Arrays;
using Operations;

namespace MatrixLib
{
    //Операция нахождения определителя матрицы
    public class Determinant : OperationThatReturnScalar
    {
        private Matrix _matrixOperand;

        //Конструктор, в котором происходит формирование операнда
        public Determinant(Matrix matrixOperand)
        {
            _matrixOperand = matrixOperand;
        }

        //Получение или изменение операнда
        public Matrix MatrixOperand
        {
            get { return _matrixOperand; }
            set { _matrixOperand = value; }
        }

        //Подсчёт определителя
        public int Calculate()
        {
            isCorrect(_matrixOperand);
            OperWithMatr op     = new OperWithMatr();
            Converter converter = new Converter();

            MWArray[] result = op.Determinant(1, converter.ConvertFromMatrixToMLMatrix(_matrixOperand));
            int resultScal   = converter.ConvertFromMLMatrixToScalar(result[0]);

            return resultScal;
        }

        //Проверка корректности операции
        private void isCorrect(Matrix matrixOperand)
        {
            if (matrixOperand.GetCountOfColumns() != matrixOperand.GetCountOfRows())
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
        }
    }
}