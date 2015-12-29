using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositryBase<T>
    {
        IList<T> getAllItems();
        void Add(T obj);
        void Edit(T obj);
        void Delete(int id);
        T getItem(int id);
    }
    public interface IRepositryBase<T,C>
    {
        IList<C> getAllItems();
        void Add(T obj);
        void Edit(T obj);
        void Delete(int id);
        T getItem(int id);
    }

    public interface IRepositryBaseCustom<T> : IRepositryBase<T>
    {
        void Edit(params int[] obj);
        void Add(params int[] obj);
    }
}
