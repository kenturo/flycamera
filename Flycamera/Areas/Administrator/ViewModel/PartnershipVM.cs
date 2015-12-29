using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class PartnershipVM
    {
        public Fly_Partnership Partnership { get; set; }
        public List<Fly_Partnership> ListPartnership { get; set; }

        public bool isPublish { get; set; }
        public bool isDelete { get; set; }

        public PartnershipVM()
        {
            Partnership = new Fly_Partnership();
            ListPartnership = new List<Fly_Partnership>();
            isPublish = true;
            isDelete = false;
        }
    }
}