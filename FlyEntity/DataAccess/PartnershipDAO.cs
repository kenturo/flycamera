using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class PartnershipDAO : IRepositryBase<Fly_Partnership>
    {
        public IList<Fly_Partnership> getAllItems()
        {
            IList<Fly_Partnership> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Partnership>();
                    item = context.Fly_Partnership.Include("Fly_Picture").Include("Fly_Customer").ToList<Fly_Partnership>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Partnership obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Partnership.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Partnership obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Partnership.Where(x => x.PartnershipID == obj.PartnershipID).FirstOrDefault();
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
                    var item = context.Fly_Partnership.Where(x => x.PartnershipID == id).FirstOrDefault();
                    item.Deleted = true;
                    if (item != null)
                    {
                        context.Entry(item).CurrentValues.SetValues((Fly_Partnership)item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Partnership getItem(int id)
        {
            Fly_Partnership obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Partnership.Include("Fly_Picture").Where(x => x.PartnershipID == id).FirstOrDefault();
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
