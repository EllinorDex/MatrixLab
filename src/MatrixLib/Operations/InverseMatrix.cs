using Operations;
using System;

namespace MatrixLib.Operations
{
    /// <summary>
    /// Inverse matrix calculation class
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    public class InverseMatrix<T> : IOperationThatReturnMatrix<T> where T : IConvertible
    {
        public Matrix<T> MatrixOperand { get; set; }
        /// <summary>
        /// Create operation InverseMatrix
        /// </summary>
        /// <param name="matrixOperand">Matrix</param>
        public InverseMatrix(Matrix<T> matrixOperand)
        {
            MatrixOperand = matrixOperand;
        }

        /// <summary>
        /// Perform InverseMatrix Operation
        /// </summary>
        /// <returns>Inverse Matrix</returns>
        public Matrix<T> Calculate()
        {
            IsCorrect(MatrixOperand);

            var result = MatLabOperation.MlOperation.InverseMatrix(1, Converter<T>.ConvertFromMatrixToMlMatrix(MatrixOperand));
            var resultArr = Converter<T>.ConvertFromMlMatrixToMatrix(result[0]);

            return new Matrix<T>(MatrixOperand.CountOfRows, MatrixOperand.CountOfColumns, resultArr);
        }

        /// <summary>
        /// Operand Validation
        /// </summary>
        /// <param name="matrixOperand">Matrix</param>
        private static void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.CountOfColumns != matrixOperand.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
            var det = new Determinant<T>(matrixOperand);
            if (Math.Abs((double)Convert.ChangeType(det.Calculate(), typeof(double)) - 0) < double.Epsilon)
                throw new MatrixException("The operation cannot be performed. Incorrect matrix.");
        }
    }
}