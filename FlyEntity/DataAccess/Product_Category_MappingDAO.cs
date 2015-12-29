﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class Product_Category_MappingDAO: IRepositryBase<Fly_Product_Category_Mapping>
    {
        public IList<Fly_Product_Category_Mapping> getAllItems()
        {
            IList<Fly_Product_Category_Mapping> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Product_Category_Mapping>();
                    item = context.Fly_Product_Category_Mapping.Include("Fly_Category").Include("Fly_Produc").ToList<Fly_Product_Category_Mapping>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Product_Category_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Product_Category_Mapping.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Product_Category_Mapping obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Product_Category_Mapping.Where(x => x.ProductID == obj.ProductID).FirstOrDefault();
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
                    var item = context.Fly_Product_Category_Mapping.Where(x => x.ProductID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_Product_Category_Mapping.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Product_Category_Mapping getItem(int id)
        {
            Fly_Product_Category_Mapping obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Product_Category_Mapping.Where(x => x.ProductID == id).FirstOrDefault();
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
