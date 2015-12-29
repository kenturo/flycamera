using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;
namespace FlyEntity.DataAccess
{
    public class PictureDAO : IRepositryPicture<Fly_Picture>
    {
        public IList<Fly_Picture> getAllItems()
        {
            IList<Fly_Picture> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_Picture>();
                    item = (from it in context.Fly_Picture
                            select it).ToList<Fly_Picture>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_Picture obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_Picture.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_Picture obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_Picture.Where(x => x.PictureID == obj.PictureID).FirstOrDefault();
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
                    var item = context.Fly_Picture.Where(x => x.PictureID == id).FirstOrDefault();
                    if (item != null)
                    {
                        context.Fly_Picture.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_Picture getItem(int id)
        {
            Fly_Picture obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Picture.Where(x => x.PictureID == id).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public Fly_Picture getItemByUrl(string Url)
        {
            Fly_Picture obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_Picture.Where(x => x.OriginalURL == Url).FirstOrDefault();
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
