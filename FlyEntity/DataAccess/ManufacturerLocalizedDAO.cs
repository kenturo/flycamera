using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class ManufacturerLocalizedDAO: IRepositryBase<Fly_ManufacturerLocalized>
    {
        public IList<Fly_ManufacturerLocalized> getAllItems()
        {
            IList<Fly_ManufacturerLocalized> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_ManufacturerLocalized>();
                    item = context.Fly_ManufacturerLocalized.Include("Fly_Language").Include("Fly_Manufacturer").ToList<Fly_ManufacturerLocalized>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_ManufacturerLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_ManufacturerLocalized.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_ManufacturerLocalized obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_ManufacturerLocalized.Where(x => x.ManufacturerID == obj.ManufacturerID).FirstOrDefault();
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
                    var item = context.Fly_ManufacturerLocalized.Where(x => x.ManufacturerID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_ManufacturerLocalized.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_ManufacturerLocalized getItem(int id)
        {
            Fly_ManufacturerLocalized obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_ManufacturerLocalized.Where(x => x.ManufacturerID == id).FirstOrDefault();
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
