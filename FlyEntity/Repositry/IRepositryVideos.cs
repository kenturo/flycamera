using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositryVideos<T> : IRepositryBase<T>
    {
        IList<T> getAllItemsByHome();
        IList<T> getAllItemsByTechnical();
        IList<T> getAllItemsByType(string type);
        IList<T> getAllItemsByProductId(int id);
    }
}
