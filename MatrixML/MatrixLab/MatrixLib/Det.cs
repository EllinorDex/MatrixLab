using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    //Класс, реализующий нахождение определителя матриц
    //Причем, работа должна производиться с матрицами, элементы которых могут быть разного типа
    public class Det<T> : OperationRS<T>
    {
        private Matrix<T> _matrix;

        public T GetResult()
        {
            return _matrix[0,0];
        }
    }
}
