using System;

namespace MatrixLib.Operations
{
    //Интерфейс операции, возвращающающей скаляр
    internal interface IOperationThatReturnScalar<out T> where T : IConvertible
    {
        T Calculate();
    }
}
