using System;
using System.Collections.Generic;
using System.Data;
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
                    var objExist = context.Fly_Customer.Find(obj.CustomerID);
                    if (objExist == null)
                    {
                        obj.IsGuest = true;
                        obj.IsAdmin = false;
                        obj.RegistrationDate = DateTime.Now;
                        obj.IsTaxExempt = false;
                        obj.Active = true;
                        obj.Deleted = false;
                        obj.PasswordHash = Encryption.Encrypt(obj.PasswordHash);
                        context.Fly_Customer.Add(obj);
                        context.SaveChanges();
                    }
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
                    var item = context.Fly_Customer
                        .Include("Fly_Picture")
                        .Include("Fly_Customer_CustomerRole_Mapping")
                        .Include("Fly_CustomerAttribute")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole.Fly_CustomerRole_Discount_Mapping")
                        .Include("Fly_Customer_CustomerRole_Mapping.Fly_CustomerRole.Fly_CustomerRole_ProductPrice")
                        .FirstOrDefault(x => x.CustomerID == obj.CustomerID);

                    if (item != null)
                    {
                        var cusAtrr = item.Fly_CustomerAttribute.FirstOrDefault();
                        context.Entry(cusAtrr).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj.Fly_CustomerAttribute.FirstOrDefault(), cusAtrr));
                        context.Entry(item).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj, item));
                    }
                    context.SaveChanges();
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
                    var item = context.Fly_Customer.FirstOrDefault(x => x.CustomerID == id);
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
                        .Include("Fly_CustomerSession").FirstOrDefault(x => x.CustomerID == id);
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
                    var user = context.Fly_Customer.SingleOrDefault(x => x.Username.Equals(usname));
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

        public Fly_Customer SignIn(string usname, string pword)
        {
            Fly_Customer obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    pword = Encryption.Encrypt(pword);
                    var user = context.Fly_Customer.SingleOrDefault(x => x.Username.Equals(usname) && x.PasswordHash.Equals(pword));
                    if (user != null)
                    {
                        obj = user;
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
                    var user = context.Fly_Customer.SingleOrDefault(x => x.Email.Equals(email));
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
                    var user = context.Fly_Customer.SingleOrDefault(x => x.Username.Equals(usname));
                    if (user != null)
                    {
                        
                        obj = (user.IsAdmin.GetValueOrDefault()) ? true :false;
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
                    var user = context.Fly_Customer.SingleOrDefault(x => x.CustomerID.Equals(id));
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
