using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib_0._1
{
    //Класс, реализующий матрицу
    public class Matrix<T>
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private T[,] _matrix;


        public Matrix(uint countOfRows, uint countOfColumns, string typeofMatrix)
        {
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

        public uint GetCountOfRows()
        {
            return _countOfRows;
        }
        public uint GetCountOfColumns()
        {
            return _countOfColumns;
        }
        public T this[int i, int j]
        {
            get { return _matrix[i, j]; }
        }
    }

     
}
