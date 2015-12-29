using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class ManufacturerDAO: IRepositryBase<Fly_Manufacturer>
    {
        public IList<Fly_Manufacturer> getAllItems()
        {
            IList<Fly_Manufacturer> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Manufacturer>();
                    item = context.Fly_Manufacturer.Include("Fly_Picture").ToList<Fly_Manufacturer>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Manufacturer obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Manufacturer.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Manufacturer obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Manufacturer.Include("Fly_ManufacturerLocalized").Where(x => x.ManufacturerID == obj.ManufacturerID).FirstOrDefault();
                    var localized = item.Fly_ManufacturerLocalized.FirstOrDefault();
                    if (item != null)
                    {
                        if (localized != null)
                            context.Entry(localized).CurrentValues.SetValues(obj.Fly_ManufacturerLocalized.FirstOrDefault());
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
                    var item = context.Fly_Manufacturer.Where(x => x.ManufacturerID == id).FirstOrDefault();
                    item.Deleted = true;
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues((Fly_Manufacturer)item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Manufacturer getItem(int id)
        {
            Fly_Manufacturer obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Manufacturer.Include("Fly_Picture").Include("Fly_ManufacturerLocalized").Where(x => x.ManufacturerID == id).FirstOrDefault();
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
