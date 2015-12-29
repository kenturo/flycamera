using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;
namespace Flycamera.ViewModel
{
    public class UserVM
    {
        public Fly_Customer Customer { get; set; }
        public Fly_CustomerAttribute CustomerAttribute { get; set; }

        public int countrySelected { get; set; }
        public string captchaText { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }

        public UserVM()
        {
            countrySelected = 116;
        }
    }
}