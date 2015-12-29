using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flycamera.App_Start
{
    public static class ConfiguationSite
    {
        /* number item per page */
        private static int _pagesize = 12;
        public static int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }

        /* number banner */
        private static int _numberBanner = 6;
        public static int NumberBanner
        {
            get { return _numberBanner; }
            set { _numberBanner = value; }
        }


        private static int _numberVideoHome = 6;
        public static int NumberVideoHome
        {
            get { return _numberVideoHome; }
            set { _numberVideoHome = value; }
        }

        private static int _numberItemNavigation = 16;
        public static int NumberItemNavigation
        {
            get { return _numberItemNavigation; }
            set { _numberItemNavigation = value; }
        }


    }
}