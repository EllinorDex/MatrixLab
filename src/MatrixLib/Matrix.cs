namespace MatrixLib
{
    //Стандартные типы матриц
    public enum MatrixType { ones = 1, zeros };

    public class Matrix
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private int[,] _matrix;

        //конструктор создания стандартных матриц
        public Matrix(uint countOfRows, uint countOfColumns, MatrixType typeOfMatrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new int[_countOfRows, _countOfColumns];
            switch (typeOfMatrix)
            {
                case MatrixType.ones:
                    if (countOfRows != countOfColumns)
                        throw new MatrixException("Unable to create matrix.Incorrect type.");

                    for (uint i = 0; i < _countOfColumns; ++i)
                        _matrix[i, i] = 1;
                    break;

                case MatrixType.zeros:
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            _matrix[i, j] = 0;
                    break;

                default:
                    break;
            }
        }

        //создание пользовательской матрицы
        public Matrix(uint countOfRows, uint countOfColumns, int[,] matrix)

        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new int[_countOfRows, _countOfColumns];
            for (uint i = 0; i < _countOfRows; ++i)
                for (uint j = 0; j < _countOfColumns; ++j)
                    _matrix[i, j] = matrix[i, j];

        }

        //Возвращение размеров матриц(думаю не стоит позволять пользователю их менять(set))
        public uint CountOfRows
        {
            get { return _countOfRows; }
            set { _countOfRows = value; }
        }
        public uint CountOfColumns
        {
            get { return _countOfColumns; }
            set { _countOfColumns = value; }
        }

        //значение в конкретной ячейке матрицы
        public int this[int i, int j]
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }

        //возвращает полностью содержимое матрицы
        public int[,] Get2DArray()
        {
            int[,] res = new int[_countOfRows,_countOfColumns];
            for (uint i = 0; i < _countOfRows; ++i)
                for (uint j = 0; j < _countOfColumns; ++j)
                    res[i, j] = _matrix[i, j];

            return res;
        }
    }
}
