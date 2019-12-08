using System;

namespace MatrixLib
{
    //Перечень стандартных типов матриц
    public enum MatrixType { ones = 1, zeros = 2 };

    //Собственно, матрица
    public class Matrix<T> where T: IConvertible
    {
        private readonly uint _countOfRows;
        private readonly uint _countOfColumns;
        private readonly T[,] _matrix;

        //Создание стандартной матрицы
        public Matrix(uint countOfRows, uint countOfColumns, MatrixType typeOfMatrix)
        {
            _countOfRows    = countOfRows;
            _countOfColumns = countOfColumns;
            _matrix         = Creator2DArray(typeOfMatrix);
        }

        //Создание нестандартной матрицы
        public Matrix(uint countOfRows, uint countOfColumns, T[,] matrix)
        {
            IsCorrect(countOfRows, countOfColumns, matrix);
            _countOfRows    = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new T[_countOfRows, _countOfColumns];
            for (uint i = 0; i < _countOfRows; ++i)
                for (uint j = 0; j < _countOfColumns; ++j)
                    _matrix[i, j] = matrix[i, j];
        }

        //Получение количества строк
        public uint GetCountOfRows()
        {
            return _countOfRows;
        }

        //Получение количества столбцов
        public uint GetCountOfColumns()
        {
            return _countOfColumns;
        }

        //Оператор индексирования
        public T this[int i, int j]
        {
            get { return _matrix[i, j]; }
        }

        //Получение внутреннего двумерного массива
        public T[,] Get2DArray()
        {
            T[,] res = new T[_countOfRows, _countOfColumns];
            for (uint i = 0; i < _countOfRows; ++i)
                for (uint j = 0; j < _countOfColumns; ++j)
                    res[i, j] = _matrix[i, j];

            return res;
        }

        //Создание двумерного массива
        private T[,] Creator2DArray(MatrixType typeOfMatrix)
        {
            T[,] d2array = new T[_countOfRows, _countOfColumns];
            switch (typeOfMatrix)
            {
                case MatrixType.ones:
                    if (_countOfRows != _countOfColumns)
                        throw new MatrixException("Unable to create matrix.Incorrect type or size.");

                    for (uint i = 0; i < _countOfColumns; ++i)
                        d2array[i, i] = (T)Convert.ChangeType(1, typeof(T));
                    break;

                case MatrixType.zeros:
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            d2array[i, j] = default(T);
                    break;
            }
            return d2array;
        }

        //Проверка корректности создания матрицы
        private void IsCorrect(uint countOfRows, uint countOfColumns, T[,] matrix)
        {
            if (matrix.GetLength(0) != countOfRows || matrix.GetLength(1) != countOfColumns)
                throw new MatrixException("Unable to create matrix.Incompatible size and 2dArray.");
        }
    }
}
