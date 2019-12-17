using Operations;
using System;

namespace MatrixLib.Operations
{
    /// <summary>
    /// Matrix sum calculation class
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    public class Sum<T> : IOperationThatReturnMatrix<T> where T : IConvertible
    { 
        public Matrix<T> MatrixLeft { get; set; }
        public Matrix<T> MatrixRight { get; set; }

        /// <summary>
        /// Create operation Sum
        /// </summary>
        /// <param name="matrixLeft">Left Matrix</param>
        /// <param name="matrixRight">Right Matrix</param>
        public Sum(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            MatrixLeft = matrixLeft;
            MatrixRight = matrixRight;
        }

        /// <summary>
        /// Perform Sum
        /// </summary>
        /// <returns>Result Matrix</returns>
        public Matrix<T> Calculate()
        {
            IsCorrect(MatrixLeft, MatrixRight);

            var result = MatLabOperation.MlOperation.Sum(1, Converter<T>.ConvertFromMatrixToMlMatrix(MatrixLeft), Converter<T>.ConvertFromMatrixToMlMatrix(MatrixRight));
            var resultArr = Converter<T>.ConvertFromMlMatrixToMatrix(result[0]);

            return new Matrix<T>(MatrixLeft.CountOfRows, MatrixLeft.CountOfColumns, resultArr);
        }

        /// <summary>
        /// Operand Validation
        /// </summary>
        /// <param name="matrixLeft">Left Matrix</param>
        /// <param name="matrixRight">Right Matrix</param>
        private static void IsCorrect(Matrix<T> matrixLeft, Matrix<T> matrixRight)
        {
            if(matrixLeft is null || matrixRight is null)
                throw new MatrixException("The operation cannot be performed. Incorrect matrix");

            if (matrixLeft.CountOfRows != matrixRight.CountOfRows || matrixLeft.CountOfColumns != matrixRight.CountOfColumns)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operands.");
        }
    }
}
