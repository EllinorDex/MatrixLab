using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    //интерфейс всех операций  возвращающих матрицу
    interface OperationRetMatrix
    {
        Matrix Calculate();
    }
}
