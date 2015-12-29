using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
using FlyEntity.Utilities;
namespace FlyEntity.DataAccess
{
    public class CustomerDAO : IRepositryCustomers<Fly_Customer>
    {
        public IList<Fly_Customer> getAllItems()
        {
            IList<Fly_Customer> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Customer>();
                    item = context.Fly_Customer
                        .Include("Fly_Picture")
                        .Include("Fly_Customer_CustomerRole_Mapping")
                        .Include("Fly_CustomerAttribute")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole.Fly_CustomerRole_Discount_Mapping")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole.Fly_CustomerRole_ProductPrice")
                        .Include("Fly_CustomerSession")
                        .ToList<Fly_Customer>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Customer obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    if (obj.IsAdmin.GetValueOrDefault())
                    {
                        obj.IsGuest = false;
                    }
                    else
                    {
                        obj.IsGuest = true;
                    }
                    obj.RegistrationDate = DateTime.Now;
                    obj.IsTaxExempt = false;
                    obj.Active = true;
                    obj.Deleted = false;
                    obj.PasswordHash = Encryption.Encrypt(obj.PasswordHash);
                    context.Fly_Customer.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Customer obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Customer.Where(x => x.CustomerID == obj.CustomerID).FirstOrDefault();
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Customer.Where(x => x.CustomerID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_Customer.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Customer getItem(int id)
        {
            Fly_Customer obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Customer
                        .Include("Fly_Picture")
                        .Include("Fly_Customer_CustomerRole_Mapping")
                        .Include("Fly_CustomerAttribute")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole.Fly_CustomerRole_Discount_Mapping")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole.Fly_CustomerRole_ProductPrice")
                        .Include("Fly_CustomerSession")
                        .Where(x => x.CustomerID == id).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public bool isExistAccount(string usname)
        {
            bool obj = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var user = context.Fly_Customer.Where(x => x.Username.Equals(usname)).SingleOrDefault();
                    if (user != null)
                    {
                        obj = true;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public string SignIn(string usname, string pword)
        {
            string obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    pword = Encryption.Encrypt(pword);
                    var user = context.Fly_Customer.Where(x => x.Username.Equals(usname) && x.PasswordHash.Equals(pword)).SingleOrDefault();
                    if (user != null)
                    {
                        obj = (user.IsAdmin.GetValueOrDefault(false)) ? RoleUser.ADMIN : RoleUser.CUSTOMER;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public bool isExistEmails(string email)
        {
            bool obj = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var user = context.Fly_Customer.Where(x => x.Email.Equals(email)).SingleOrDefault();
                    if (user != null)
                    {
                        obj = true;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public bool RoleIsAdmin(string usname)
        {
            bool obj = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var user = context.Fly_Customer.Where(x => x.Username.Equals(usname)).SingleOrDefault();
                    if (user != null)
                    {
                        obj = true;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public bool activeAdmin(int id, bool isAdmin)
        {
            bool obj = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var user = context.Fly_Customer.Where(x => x.CustomerID.Equals(id)).SingleOrDefault();
                    if (user != null)
                    {
                        user.IsAdmin = isAdmin;
                        if (user.IsAdmin.GetValueOrDefault())
                        {
                            user.IsGuest = false;
                        }
                        else
                        {
                            user.IsGuest = true;
                        }
                        obj = true;
                        context.Entry(user).CurrentValues.SetValues(user);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
