using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    //Класс, реализующий матрицу
    public class Matrix<T>
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private T[,] _matrix;


        public Matrix(uint countOfRows, uint countOfColumns, string typeofMatrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new T[_countOfColumns, _countOfRows];
            switch (typeofMatrix)
            {
                case "ones":
                    for (uint i = 0; i < _countOfColumns; ++i)
                            _matrix[i, i] = _matrix[i, i];
                    break;
                case "zeros":
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            _matrix[j, i] = _matrix[i, i];
                    break;
                default:
                    break;
            }
        }

        public Matrix(uint countOfRows, uint countOfColumns, T[,] matrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

            _matrix = new T[_countOfColumns,_countOfRows];
            for (uint i = 0; i < _countOfColumns; ++i)
                for (uint j = 0; j < _countOfRows; ++j)
                    _matrix[i,j] = matrix[i, j];
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
        public T this[int i, int j]
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }
    }

     
}
