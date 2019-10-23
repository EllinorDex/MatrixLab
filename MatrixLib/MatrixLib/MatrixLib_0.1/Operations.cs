using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib_0._1
{
    interface Operation<T>
    {
        T GetResultScalar();
        T[][] GetResultMatrix();
    }


    public class Sum<T> : Operation<T>
    {
        private T[][] _matrixLeft;
        private T[][] _matrixRight;

        public T[][] GetResultMatrix()
        {
            return null;
        }
        public T GetResultScalar()
        {
            return _matrixLeft[0][0];
        }
    }

    public class Mult<T> : Operation<T>
    {
        private T[][] _matrixLeft;
        private T[][] _matrixRight;

        public T[][] GetResultMatrix()
        {
            return null;
        }
        public T GetResultScalar()
        {
            return _matrixLeft[0][0];
        }
    }

    public class Det<T> : Operation<T>
    {
        private T[][] _matrix;

        public T[][] GetResultMatrix()
        {
            return _matrix;
        }
        public T GetResultScalar()
        {
            return _matrix[0][0];
        }
    }

    public class Inv<T> : Operation<T>
    {
        private T[][] _matrix;

        public T[][] GetResultMatrix()
        {
            return _matrix;
        }
        public T GetResultScalar()
        {
            return _matrix[0][0];
        }
    }
}
