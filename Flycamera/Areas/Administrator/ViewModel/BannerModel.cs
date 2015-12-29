using FlyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class BannerModel
    {
        public Fly_Banner banner { get; set; }
        public List<Fly_Banner> listBanner { get; set; }
        public List<Fly_BannerType> listBannerType { get; set; }

        public IEnumerable<SelectListItem> PositionBannerType { get; set; }


        public int positionType { get; set; }
        public bool isPublish { get; set; }
        public bool isDelete { get; set; }

        public BannerModel()
        {
            banner = new Fly_Banner();
            listBanner = new List<Fly_Banner>();
            listBannerType = new List<Fly_BannerType>();
            isPublish = true;
            isDelete = false;

            positionType = 1;
        }
    }
}