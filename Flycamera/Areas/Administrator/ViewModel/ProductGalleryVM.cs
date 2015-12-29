using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
using FlyEntity.DataAccess;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class ProductGalleryVM
    {
        /* Attribute */
        public Fly_PositionGallery PositionGalleries { get; set; }
        public Fly_SectionGallery SectionGalleries { get; set; }
        public Fly_SectionContent SectionContents { get; set; }

        public List<Fly_PositionGallery> ListPositionGalleries;
        public List<Fly_SectionGallery> ListSectionGalleries;
        public List<Fly_SectionContent> ListSectionContents;

        public int position { get; set; }
        public string CollectUrlGallery { get; set; }
        public IEnumerable<SelectListItem> PositionGalleriesItemList { get; set; }
        List<SelectListItem> ListItem;

        /* DataAccess */
        PositionGalleryDAO posGallery;
        SectionGalleryDAO sectionGallery;

        /* contructor */
        public ProductGalleryVM()
        {
            ListPositionGalleries = new List<Fly_PositionGallery>();
            ListSectionGalleries = new List<Fly_SectionGallery>();
            ListSectionContents = new List<Fly_SectionContent>();
            posGallery = new PositionGalleryDAO();
            sectionGallery = new SectionGalleryDAO();
        }
    }
}