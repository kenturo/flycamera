using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace FlyEntity.DataAccess
{
    public class CustomerMappingRoleDao : IRepositryMappingRole<Fly_Customer_CustomerRole_Mapping>
    {

        public IList<Fly_Customer_CustomerRole_Mapping> getAllItems()
        {
            IList<Fly_Customer_CustomerRole_Mapping> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Customer_CustomerRole_Mapping>();
                    item = context.Fly_Customer_CustomerRole_Mapping.ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Customer_CustomerRole_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    Fly_Customer_CustomerRole_Mapping objExist =
                        context.Fly_Customer_CustomerRole_Mapping.SingleOrDefault(x => x.CustomerRoleID == obj.CustomerRoleID && x.CustomerID.Equals(obj.CustomerID));
                    if (objExist == null)
                    {
                        context.Fly_Customer_CustomerRole_Mapping.Add(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Customer_CustomerRole_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Customer_CustomerRole_Mapping.FirstOrDefault(x => x.CustomerRoleID == obj.CustomerRoleID);
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues(UpdateEntities.UpdateEntity(obj, item));
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
                    var item = context.Fly_Customer_CustomerRole_Mapping.FirstOrDefault(x => x.CustomerRoleID == id);
                    if (item != null)
                    {
                        context.Fly_Customer_CustomerRole_Mapping.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Customer_CustomerRole_Mapping getItem(int id)
        {
            Fly_Customer_CustomerRole_Mapping obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Customer_CustomerRole_Mapping.FirstOrDefault(x => x.CustomerRoleID == id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public List<Fly_Customer_CustomerRole_Mapping> GetAllItemByCustomerId(int id)
        {
            List<Fly_Customer_CustomerRole_Mapping> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Customer_CustomerRole_Mapping>();
                    item = context.Fly_Customer_CustomerRole_Mapping.Where(x=>x.CustomerID.Equals(id)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public bool RemoveItemById(int mappingRoleId, int customerId)
        {
            bool isSuccess = false;
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Customer_CustomerRole_Mapping.FirstOrDefault(x => x.CustomerRoleID == mappingRoleId && x.CustomerID.Equals(customerId));
                    if (item != null)
                    {
                        context.Fly_Customer_CustomerRole_Mapping.Remove(item);
                        context.SaveChanges();
                        isSuccess = true;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return isSuccess;
        }
    }
}