using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositryProducts<T>:IRepositryBase<T>
    {
        T getItem(int proId, int pos);
        T getItem(int proId, string posName);
    }
}
