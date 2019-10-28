﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    //Класс, реализующий суммирование матриц
    //Причем, работа должна производиться с матрицами, элементы которых могут быть разного типа
    public class Sum<T> : OperationRM<T>
    {
        private Matrix<T> _matrixLeft;
        private Matrix<T> _matrixRight;

        public Matrix<T> GetResult()
        {
            return _matrixLeft;
        }
    }
}
