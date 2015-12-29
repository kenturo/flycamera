using System.Collections.Generic;

namespace FlyEntity.Repositry
{
    public interface IRepositryOrderProductVariant<T> : IRepositryBase<T>
    {
        List<T> GetItemByOrderId(int orderid);
    }
}