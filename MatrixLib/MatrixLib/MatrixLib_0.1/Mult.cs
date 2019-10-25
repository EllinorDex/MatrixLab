using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib_0._1
{
    //Класс, реализующий умножение матриц
    //Причем, работа должна производиться с матрицами, элементы которых могут быть разного типа
    public class Mult<T> : Operation<T>
    {
        private Matrix<T> _matrixLeft;
        private Matrix<T> _matrixRight;

        public Matrix<T> GetResultMatrix()
        {
            return _matrixLeft;
        }
        public T GetResultScalar()
        {
            return T();
        }
    }
}
