using System;

namespace MatrixLib
{
    /// <summary>
    /// Сlass Matrix representing a mathematical object matrix.
    /// </summary>
    /// <typeparam name="T">Type of values.</typeparam>
    public class Matrix<T> where T : IConvertible
    {
        public int CountOfRows { get; }
        public int CountOfColumns { get; }
        private readonly T[,] _matrix;

        /// <summary>
        /// Construct a new Matrix.
        /// </summary>
        /// <param name="countOfRows">The count of matrix rows.</param>
        /// <param name="countOfColumns">The count of matrix columns.</param>
        /// <param name="matrix">Two-dimensional array of matrix values.</param>
        public Matrix(int countOfRows, int countOfColumns, T[,] matrix)
        {
            IsCorrect(countOfRows, countOfColumns, matrix);
            CountOfRows = countOfRows;
            CountOfColumns = countOfColumns;

            _matrix = new T[CountOfRows, CountOfColumns];
            for (var i = 0; i < CountOfRows; ++i)
                for (var j = 0; j < CountOfColumns; ++j)
                    _matrix[i, j] = matrix[i, j];
        }

        /// <summary>
        /// Getting an item by row and column.
        /// </summary>
        /// <param name="i">Row number</param>
        /// <param name="j">Column number</param>
        /// <returns>Item</returns>
        public T this[int i, int j] => _matrix[i, j];

        /// <summary>
        /// Getting an array of matrix values.
        /// </summary>
        /// <returns>Two-dimensional array of matrix values.</returns>
        public T[,] Get2DArray()
        {
            var d2Array = new T[CountOfRows, CountOfColumns];
            for (var i = 0; i < CountOfRows; ++i)
                for (var j = 0; j < CountOfColumns; ++j)
                    d2Array[i, j] = _matrix[i, j];

            return d2Array;
        }

        /// <summary>
        /// Validation of setting matrix fields.
        /// </summary>
        /// <param name="countOfRows">The count of matrix rows.</param>
        /// <param name="countOfColumns">The count of matrix columns.</param>
        /// <param name="matrix">Two-dimensional array of matrix values.</param>
        private static void IsCorrect(int countOfRows, int countOfColumns, T[,] matrix)
        {
            if (countOfRows <= 0 || countOfColumns <= 0)
                throw new MatrixException("Unable to create matrix.Invalid sizes.");

            if (matrix.GetLength(0) != countOfRows || matrix.GetLength(1) != countOfColumns)
                throw new MatrixException("Unable to create matrix.Incompatible size and 2dArray.");
        }

        /// <summary>
        /// Create a ones matrix.
        /// </summary>
        /// <param name="countOfRows">The count of matrix rows.</param>
        /// <param name="countOfColumns">The count of matrix columns.</param>
        /// <returns>Created matrix.</returns>
        public static Matrix<T> CreateOnesMatrix(int countOfRows, int countOfColumns)
        {
            if (countOfRows != countOfColumns)
                throw new MatrixException("Unable to create matrix. Invalid sizes.");

            var d2Array = new T[countOfRows, countOfColumns];
            for (var i = 0; i < countOfColumns; ++i)
                d2Array[i, i] = (T)Convert.ChangeType(1, typeof(T));

            return new Matrix<T>(countOfRows, countOfColumns, d2Array);
        }

        /// <summary>
        /// Create a zero matrix.
        /// </summary>
        /// <param name="countOfRows">The count of matrix rows.</param>
        /// <param name="countOfColumns">The count of matrix columns.</param>
        /// <returns>Created matrix.</returns>
        public static Matrix<T> CreateZeroMatrix(int countOfRows, int countOfColumns)
        {
            var d2Array = new T[countOfRows, countOfColumns];
            for (var i = 0; i < countOfRows; ++i)
                for (var j = 0; j < countOfColumns; ++j)
                    d2Array[i, j] = default(T);

            return new Matrix<T>(countOfRows, countOfColumns, d2Array);
        }
    }
}
