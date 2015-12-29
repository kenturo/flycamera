using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flycamera.Model
{
    public class BreadcrumbsModel
    {
        public bool isFirst { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool isLast { get; set; }
    }
}