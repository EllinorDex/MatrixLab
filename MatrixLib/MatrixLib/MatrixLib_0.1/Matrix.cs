using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib_0._1
{
    public class Matrix<T>
    {
        private uint _countOfRows;
        private uint _countOfColumns;
        private T[][] _matrix;


        public Matrix()
        {
        }
        public Matrix(uint countOFRows, uint countOfColumns, string typeofMatrix)
        {
        }
        public Matrix(uint countOFRows, uint countOfColumns, T[][] matrix)
        {
        }

        public uint GetCountOfRows()
        {
            return 0;
        }
        public uint GetCountOfColumns()
        {
            return 0;
        }
        ~Matrix()
        {
        }
    }
}
