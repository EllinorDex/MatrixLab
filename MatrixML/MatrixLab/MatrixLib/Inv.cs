using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    //Класс, реализующий нахождение обраной матрицы
    //Причем, работа должна производиться с матрицами, элементы которых могут быть разного типа
    public class Inv<T> : OperationRM<T>
    {
        private Matrix<T> _matrix;

        public Matrix<T> GetResult()
        {
            return _matrix;
        }
    }
}
