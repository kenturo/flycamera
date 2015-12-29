using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyEntity.Repositry;

namespace FlyEntity.DataAccess
{
    public class SectionContentDAO : IRepositrySectionContent<Fly_SectionContent>
    {
        public IList<Fly_SectionContent> getAllItems()
        {
            IList<Fly_SectionContent> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_SectionContent>();
                    item = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").ToList<Fly_SectionContent>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public void Add(Fly_SectionContent obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    context.Fly_SectionContent.Add(obj);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Edit(Fly_SectionContent obj)
        {
            try
            {
                using (var context = new flycameraEntities())
                {
                    var item = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.SectionContentID == obj.SectionContentID);
                    if (item != null)
                    {
                        obj.FullDescription = (obj.FullDescription == null || obj.FullDescription.Equals(item.FullDescription)) ? item.FullDescription : obj.FullDescription;
                        obj.FullDescription_EN = (obj.FullDescription_EN == null || obj.FullDescription_EN.Equals(item.FullDescription_EN)) ? item.FullDescription_EN : obj.FullDescription_EN;
                        obj.PositionGalleryID = (obj.PositionGalleryID > 0 || obj.PositionGalleryID == null || obj.PositionGalleryID.Equals(item.PositionGalleryID)) ? item.PositionGalleryID : obj.PositionGalleryID;
                        obj.ProductID = (obj.ProductID > 0 || obj.ProductID == null || obj.ProductID.Equals(item.ProductID)) ? item.ProductID : obj.ProductID;
                        obj.CreatedOn = (obj.CreatedOn == null || obj.CreatedOn.Equals(item.CreatedOn)) ? item.CreatedOn : obj.CreatedOn;
                        obj.UpdateOn = DateTime.Now;

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
                    var item = context.Fly_SectionContent.FirstOrDefault(x => x.SectionContentID == id);
                    if (item != null)
                    {
                        context.Fly_SectionContent.Remove(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public Fly_SectionContent getItem(int id)
        {
            Fly_SectionContent obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.ProductID == id);
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }

        public IList<Fly_SectionContent> getAllItemsByPosition(int pos, int productId)
        {
            IList<Fly_SectionContent> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_SectionContent>();
                    item = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").Where(x => x.PositionGalleryID == pos && x.ProductID == productId).ToList<Fly_SectionContent>();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }

        public Fly_SectionContent getItemsByPosition(int pos, int productId)
        {
            Fly_SectionContent obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").Where(x => x.PositionGalleryID == pos && x.ProductID == productId).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public IList<Fly_SectionContent> getAllItemsByPosition(string pos)
        {
            IList<Fly_SectionContent> item = null;

            try
            {
                using (var context = new flycameraEntities())
                {
                    item = new List<Fly_SectionContent>();
                    item = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").Where(x => x.Fly_PositionGallery.PositionName == pos).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return item;
        }


        public Fly_SectionContent getItemsByPosition(string pos)
        {
            Fly_SectionContent obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").Where(x => x.Fly_PositionGallery.PositionName == pos).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            return obj;
        }


        public Fly_SectionContent GetItemByProductAndType(int productid, string namePos)
        {
            Fly_SectionContent obj = null;
            try
            {
                using (var context = new flycameraEntities())
                {
                    obj = context.Fly_SectionContent.Include("Fly_PositionGallery").Include("Fly_Product").FirstOrDefault(x => x.ProductID == productid && x.Fly_PositionGallery.PositionName_EN == namePos);
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
