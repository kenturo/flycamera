using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositryPicture<T> : IRepositryBase<T>
    {
        T getItemByUrl(string Url);
    }
}
