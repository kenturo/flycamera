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
    public class SectionGalleryDAO : IRepositrySectionGallery<Fly_SectionGallery>
    {
        public IList<Fly_SectionGallery> getAllItems()
        {
            IList<Fly_SectionGallery> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_SectionGallery>();
                    item = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").ToList<Fly_SectionGallery>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_SectionGallery obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_SectionGallery.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_SectionGallery obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.SectionGalleryID == obj.SectionGalleryID);
                    if (item != null)
                    {
                        obj.BackgroundImage = (obj.BackgroundImage == null ||
                                               obj.BackgroundImage.Equals(item.BackgroundImage))
                            ? item.BackgroundImage
                            : obj.BackgroundImage;
                        obj.CollectionImage = (obj.CollectionImage == null ||
                                               obj.CollectionImage.Equals(item.CollectionImage))
                            ? item.CollectionImage
                            : obj.CollectionImage;
                        obj.PositionGalleryID = (obj.PositionGalleryID > 0 || obj.PositionGalleryID == null ||
                                                 obj.PositionGalleryID.Equals(item.PositionGalleryID))
                            ? item.PositionGalleryID
                            : obj.PositionGalleryID;
                        obj.ProductID = (obj.ProductID > 0 || obj.ProductID == null ||
                                         obj.ProductID.Equals(item.ProductID))
                            ? item.ProductID
                            : obj.ProductID;

                        context.Entry(item).CurrentValues.SetValues(obj);
                        context.SaveChanges();
                    }
                    else
                    {
                        this.Add(obj);
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
                    var item = context.Fly_SectionGallery.FirstOrDefault(x => x.SectionGalleryID == id);
                    if (item != null)
                    {
                        context.Fly_SectionGallery.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_SectionGallery getItem(int id)
        {
            Fly_SectionGallery obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.ProductID == id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public ICollection<Fly_SectionGallery> getAllItemsByPosition(int pos, int productId)
        {
            IList<Fly_SectionGallery> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_SectionGallery>();
                    item = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").Where(x => x.PositionGalleryID == pos && x.ProductID == productId).ToList<Fly_SectionGallery>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public Fly_SectionGallery getItemsByPosition(int pos, int productId)
        {
            Fly_SectionGallery obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").Where(x => x.PositionGalleryID == pos && x.ProductID == productId).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public Fly_SectionGallery GetItemByProductAndType(int productid, string namePos)
        {
            Fly_SectionGallery obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.ProductID == productid && x.Fly_PositionGallery.PositionName_EN == namePos);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public Fly_SectionGallery GetItemByProductAndTwoType(int productid, string namePos1, string namePos2)
        {
            Fly_SectionGallery obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionGallery.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.ProductID == productid && x.Fly_PositionGallery.PositionName_EN == namePos1 && x.Fly_PositionGallery.PositionName_EN == namePos2);
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
