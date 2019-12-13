using System;

namespace MatrixLib
{
    //Перечень стандартных типов матриц
    public enum MatrixType { Ones = 1, Zeros = 2 };

    //Собственно, матрица
    public class Matrix<T> where T: IConvertible
    {
        public int CountOfRows { get; }
        public int CountOfColumns { get; }
        private readonly T[,] _matrix;

        //Создание стандартной матрицы
        public Matrix(int countOfRows, int countOfColumns, MatrixType typeOfMatrix)
        {
            CountOfRows    = countOfRows;
            CountOfColumns = countOfColumns;
            _matrix         = Creator2DArray(typeOfMatrix);
        }

        //Создание нестандартной матрицы
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

        //Оператор индексирования
        public T this[int i, int j] => _matrix[i, j];

        //Получение внутреннего двумерного массива
        public T[,] Get2DArray()
        {
            var res = new T[CountOfRows, CountOfColumns];
            for (var i = 0; i < CountOfRows; ++i)
                for (var j = 0; j < CountOfColumns; ++j)
                    res[i, j] = _matrix[i, j];

            return res;
        }

        //Создание двумерного массива
        private T[,] Creator2DArray(MatrixType typeOfMatrix)
        {
            var d2Array = new T[CountOfRows, CountOfColumns];
            switch (typeOfMatrix)
            {
                case MatrixType.Ones:
                    if (CountOfRows != CountOfColumns)
                        throw new MatrixException("Unable to create matrix.Incorrect type or size.");

                    for (int i = 0; i < CountOfColumns; ++i)
                        d2Array[i, i] = (T)Convert.ChangeType(1, typeof(T));
                    break;

                case MatrixType.Zeros:
                    for (int i = 0; i < CountOfRows; ++i)
                        for (int j = 0; j < CountOfColumns; ++j)
                            d2Array[i, j] = default(T);
                    break;
            }

            return d2Array;
        }

        //Проверка корректности создания матрицы
        private static void IsCorrect(int countOfRows, int countOfColumns, T[,] matrix)
        {
            if (matrix.GetLength(0) != countOfRows || matrix.GetLength(1) != countOfColumns)
                throw new MatrixException("Unable to create matrix.Incompatible size and 2dArray.");
        }
    }
}
