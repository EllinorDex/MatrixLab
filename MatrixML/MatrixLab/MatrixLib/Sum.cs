﻿using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Text;

namespace MatrixLib
{
    public class Sum : OperationRetMatrix
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        public Matrix GetResult()
=======
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
>>>>>>> a6b819a89422fed1c4f5fd23284849088f547983
        {
            return _matrixLeft;
        }
    }
}
