using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class PositionGalleryDAO : IRepositryPositionGallery<Fly_PositionGallery>
    {

        public IList<Fly_PositionGallery> getAllItems()
        {
            IList<Fly_PositionGallery> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_PositionGallery>();
                    item = (from it in context.Fly_PositionGallery
                            select it).ToList<Fly_PositionGallery>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_PositionGallery obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_PositionGallery.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_PositionGallery obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_PositionGallery.FirstOrDefault(x => x.PositionGalleryID == obj.PositionGalleryID);
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
                    var item = context.Fly_PositionGallery.FirstOrDefault(x => x.PositionGalleryID == id);
                    if (item != null)
                    {
                        context.Fly_PositionGallery.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_PositionGallery getItem(int id)
        {
            Fly_PositionGallery obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_PositionGallery.FirstOrDefault(x => x.PositionGalleryID == id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public Fly_PositionGallery GetItemByPosName(string posname)
        {
            Fly_PositionGallery obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_PositionGallery.FirstOrDefault(x => x.PositionName_EN == posname);
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
