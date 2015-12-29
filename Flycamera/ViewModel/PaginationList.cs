using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flycamera.ViewModel
{
    public class PaginationList
    {
        public int TotalItem { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        private decimal _pagenumber;

        public int PageNumber
        {
            get {
                if (this.TotalItem <= this.PageSize) _pagenumber = 1;
                if (this.TotalItem % this.PageSize == 0)
                    _pagenumber = this.TotalItem / this.PageSize;
                else
                    _pagenumber = this.TotalItem / this.PageSize + 1;

                return Convert.ToInt32(Math.Floor(_pagenumber)); 
            }
        }
    }
}