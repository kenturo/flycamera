using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlyEntity.Utilities;

namespace FlyEntity.Repositry
{
    public interface IRepositryOrder<T> : IRepositryBase<T>
    {
        List<T> GetAllListOrderNotApprove();
        List<T> GetAllListOrderByStatus(string status);
        bool SetApproveOrder(int orderid, int userId);
        bool SetCompleteOrder(int orderid);
        bool SetCancelOrder(int orderid);
    }
}
