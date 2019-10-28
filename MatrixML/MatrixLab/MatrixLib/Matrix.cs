using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Text;

namespace MatrixLib
{
    public class Matrix
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private int[,] _matrix;
=======
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
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983


        public Matrix(uint countOfRows, uint countOfColumns, string typeofMatrix)
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

<<<<<<< HEAD
            _matrix = new int[_countOfColumns, _countOfRows];
=======
            _matrix = new T[_countOfColumns, _countOfRows];
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
            switch (typeofMatrix)
            {
                case "ones":
                    for (uint i = 0; i < _countOfColumns; ++i)
<<<<<<< HEAD
                        _matrix[i, i] = 1;
                    break;
                //почему мы в нуливую матрицу не просто нули закидываем?
                case "zeros":
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            _matrix[j, i] = 0;
=======
                            _matrix[i, i] = _matrix[i, i];
                    break;
                    //почему мы в нуливую матрицу не просто нули закидываем?
                case "zeros":
                    for (uint i = 0; i < _countOfRows; ++i)
                        for (uint j = 0; j < _countOfColumns; ++j)
                            _matrix[j, i] = _matrix[i, i];
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
                    break;
                default:
                    break;
            }
        }

<<<<<<< HEAD
        public Matrix(uint countOfRows, uint countOfColumns, int[,] matrix)
=======
        public Matrix(uint countOfRows, uint countOfColumns, T[,] matrix)
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
        {
            _countOfRows = countOfRows;
            _countOfColumns = countOfColumns;

<<<<<<< HEAD
            _matrix = new int[_countOfColumns, _countOfRows];
            for (uint i = 0; i < _countOfColumns; ++i)
                for (uint j = 0; j < _countOfRows; ++j)
                    _matrix[i, j] = matrix[i, j];
=======
            _matrix = new T[_countOfColumns,_countOfRows];
            for (uint i = 0; i < _countOfColumns; ++i)
                for (uint j = 0; j < _countOfRows; ++j)
                    _matrix[i,j] = matrix[i, j];
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
        }

        public uint CountOfRows
        {
            get { return _countOfRows; }
<<<<<<< HEAD
=======
            //помоему, нам не нужно позволять изменять значения строк и столбцов
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
            set { _countOfRows = value; }
        }
        public uint CountOfColumns
        {
            get { return CountOfColumns; }
            set { _countOfColumns = value; }
        }
<<<<<<< HEAD
        public int this[int i, int j]
=======
        public T this[int i, int j]
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }
    }
<<<<<<< HEAD
=======

     
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
}
