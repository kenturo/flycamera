using System.Collections.Generic;

namespace FlyEntity.Repositry
{
    public interface IRepositryMappingRole<T> : IRepositryBase<T>
    {
        List<T> GetAllItemByCustomerId(int id);
        bool RemoveItemById(int mappingRoleId, int customerId);
    }
}