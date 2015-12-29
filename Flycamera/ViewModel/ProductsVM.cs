using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;

namespace Flycamera.ViewModel
{
    public class ProductsVM
    {
        public string ProductName { get; set; }
        public int? ProductID { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceAdmin { get; set; }
        public bool? isCallForFrice { get; set; }
        public string ProductLink { get; set; }
        public string ImageLink { get; set; }
        public bool? isHot { get; set; }
        public bool? isNew { get; set; }
        public bool? isGift { get; set; }

        public IList<Fly_Partnership> listPartnerships { get; set; }
        public IList<Fly_Product> ProductList { get; set; }
        public IList<Fly_ProductLocalized> ProductLocalizedList { get; set; }
        public IList<Fly_ProductVariant> ProductVariantList { get; set; }
        public IList<Fly_ProductVariantLocalized> ProductVariantLocalizedList { get; set; }
        public IList<Fly_ProductPicture> ProductPictureList { get; set; }
        public IList<Fly_Videos> ListVideos { get; set; }
        public Fly_SectionGallery SectionGalleries { get; set; }
        public Fly_ProductVariant ProductVariant { get; set; }
        


        public Fly_Product Products { get; set; }

    }
}