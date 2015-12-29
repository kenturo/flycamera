using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Repositry
{
    public interface IRepositryCustomers<T> : IRepositryBase<T>
    {
        bool isExistAccount(string usname);
        bool isExistEmails(string email);
        T SignIn(string usname, string pword);
        bool RoleIsAdmin(string usname);
        bool activeAdmin(int id,bool isAdmin);
    }
}
