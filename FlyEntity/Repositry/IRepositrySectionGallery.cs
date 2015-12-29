using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositrySectionGallery<T> : IRepositryBase<T>
    {
        ICollection<T> getAllItemsByPosition(int pos, int productId);
        T getItemsByPosition(int pos, int productId);

        T GetItemByProductAndType(int productid, string namePos);
        T GetItemByProductAndTwoType(int productid, string namePos1, string namePos2);

    }
}
