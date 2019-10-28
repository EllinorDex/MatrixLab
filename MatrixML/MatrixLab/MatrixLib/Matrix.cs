using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    public class Matrix
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private int[,] _matrix;

        public Matrix(uint countOfRows, uint countOfColumns, string typeofMatrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new int[_countOfColumns, _countOfRows];

            switch (typeofMatrix)
            {
                case "ones":
                    for (uint i = 0; i < _countOfColumns; ++i)

                        _matrix[i, i] = 1;
                    break;
                case "zeros":
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            _matrix[j, i] = 0;

                    break;
                default:
                    break;
            }
        }

        public Matrix(uint countOfRows, uint countOfColumns, int[,] matrix)

        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new int[_countOfColumns, _countOfRows];
            for (uint i = 0; i < _countOfColumns; ++i)
                for (uint j = 0; j < _countOfRows; ++j)
                    _matrix[i, j] = matrix[i, j];

        }

        public uint CountOfRows
        {
            get { return _countOfRows; }
            set { _countOfRows = value; }
        }
        public uint CountOfColumns
        {
            get { return CountOfColumns; }
            set { _countOfColumns = value; }
        }
        public int this[int i, int j]
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }
        public int[,] GetMatrix()
        {
            return _matrix;
        }
    }
}
