using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class DiscountVm
    {
        public List<Fly_Discount> ListDiscount { get; set; }
        public Fly_Discount FlyDiscount { get; set; }
        public bool Deleted { get; set; }

        public DiscountVm()
        {
            ListDiscount = new List<Fly_Discount>();
            FlyDiscount = new Fly_Discount();
            Deleted = false;
        }
    }
}