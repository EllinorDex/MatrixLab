namespace MatrixLib
{
    //Перечень стандартных типов матриц
    public enum MatrixType { ones = 1, zeros = 2 };

    //Собственно, матрица
    public class Matrix
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private int[,] _matrix;

        //Создание стандартной матрицы
        public Matrix(uint countOfRows, uint countOfColumns, MatrixType typeOfMatrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;
            _matrix = creator2DArray(typeOfMatrix);
        }

        //Создание нестандартной матрицы
        public Matrix(uint countOfRows, uint countOfColumns, int[,] matrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new int[_countOfRows, _countOfColumns];
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
        public int this[int i, int j]
        {
            get { return _matrix[i, j]; }
        }

        //Получение внутреннего двумерного массива
        public int[,] Get2DArray()
        {
            int[,] res = new int[_countOfRows, _countOfColumns];
            for (uint i = 0; i < _countOfRows; ++i)
                for (uint j = 0; j < _countOfColumns; ++j)
                    res[i, j] = _matrix[i, j];

            return res;
        }

        private int[,] creator2DArray(MatrixType typeOfMatrix)
        {
            int[,] d2array = new int[_countOfRows, _countOfColumns];
            switch (typeOfMatrix)
            {
                case MatrixType.ones:
                    if (_countOfRows != _countOfColumns)
                        throw new MatrixException("Unable to create matrix.Incorrect type or size.");

                    for (uint i = 0; i < _countOfColumns; ++i)
                        d2array[i, i] = 1;
                    break;

                case MatrixType.zeros:
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            d2array[i, j] = 0;
                    break;

                default:
                    break;
            }
            return d2array;
        }
    }
}
