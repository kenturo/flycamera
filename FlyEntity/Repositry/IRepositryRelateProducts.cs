using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositryRelateProducts<T> : IRepositryBase<T>
    {
        IList<T> getAllItemsByProductID(int id);
    }
}
