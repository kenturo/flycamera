//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlyEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fly_BlogPost
    {
        public int BlogPostID { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public string BlogPostTitle { get; set; }
        public string BlogPostShortContent { get; set; }
        public string BlogPostBody { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> BlogPostTypeID { get; set; }
        public string VideoLink { get; set; }
        public string Tags { get; set; }
        public Nullable<bool> Published { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual Fly_BlogPostType Fly_BlogPostType { get; set; }
        public virtual Fly_Customer Fly_Customer { get; set; }
        public virtual Fly_Language Fly_Language { get; set; }
    }
}
