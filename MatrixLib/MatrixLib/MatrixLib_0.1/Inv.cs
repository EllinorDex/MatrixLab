using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib_0._1
{
    //Класс, реализующий нахождение обраной матрицы
    //Причем, работа должна производиться с матрицами, элементы которых могут быть разного типа
    public class Inv<T> : Operation<T>
    {
        private Matrix<T> _matrix;

        public Matrix<T> GetResultMatrix()
        {
            return _matrix;
        }
        public T GetResultScalar()
        {
            return null;
        }
    }
}
