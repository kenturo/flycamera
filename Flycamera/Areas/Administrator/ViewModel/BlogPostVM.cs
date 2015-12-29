using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlyEntity;

namespace Flycamera.Areas.Administrator.ViewModel
{
    public class BlogPostVm
    {
        /* Attribute */
        public Fly_BlogPost Blogpost { get; set; }
        public Fly_BlogPostType BlogpostType { get; set; }

        public List<Fly_BlogPost> ListBlogPost { get; set; }
        public List<Fly_BlogPostType> ListBlogPostType { get; set; }

        public IEnumerable<SelectListItem> PosBlogTypeList { get; set; }
        List<SelectListItem> _listItem;
        public int IsVideo { get; set; }
        public bool IsPublish { get; set; }

        public BlogPostVm()
        {
            _listItem = new List<SelectListItem>();
            ListBlogPost = new List<Fly_BlogPost>();
            ListBlogPostType = new List<Fly_BlogPostType>();
            IsPublish = true;
        }
    }
}