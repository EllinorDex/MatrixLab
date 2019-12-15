using Operations;
using System;

namespace MatrixLib.Operations
{
    /// <summary>
    /// Matrix determinant calculation class
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    public class Determinant<T> : IOperationThatReturnScalar<T> where T : IConvertible
    {
        public Matrix<T> MatrixOperand { get; set; }

        /// <summary>
        /// Create operation Determinant
        /// </summary>
        /// <param name="matrixOperand">Matrix</param>
        public Determinant(Matrix<T> matrixOperand)
        {
            MatrixOperand = matrixOperand;
        }

        /// <summary>
        /// Perform Determinant Operation
        /// </summary>
        /// <returns>Determinant matrix</returns>
        public T Calculate()
        {
            IsCorrect(MatrixOperand);

            var result = MatLabOperation.MlOperation.Determinant(1, Converter<T>.ConvertFromMatrixToMlMatrix(MatrixOperand));
            var resultScal = Converter<T>.ConvertFromMlMatrixToScalar(result[0]);

            return resultScal;
        }

        /// <summary>
        /// Operand Validation
        /// </summary>
        /// <param name="matrixOperand">Matrix</param>
        private static void IsCorrect(Matrix<T> matrixOperand)
        {
            if (matrixOperand.CountOfColumns != matrixOperand.CountOfRows)
                throw new MatrixException("The operation cannot be performed. Incorrect sizes of operand.");
        }
    }
}