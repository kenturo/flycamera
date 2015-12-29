using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositrySectionContent<T> : IRepositryBase<T>
    {
        IList<T> getAllItemsByPosition(int pos, int productId);
        IList<T> getAllItemsByPosition(string pos);
        T getItemsByPosition(int pos, int productId);
        T getItemsByPosition(string pos);

        T GetItemByProductAndType(int productid, string namePos);

    }
}
