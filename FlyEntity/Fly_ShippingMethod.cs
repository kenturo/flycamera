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
    
    public partial class Fly_ShippingMethod
    {
        public Fly_ShippingMethod()
        {
            this.Fly_Order = new HashSet<Fly_Order>();
        }
    
        public int ShippingMethodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    
        public virtual Fly_Language Fly_Language { get; set; }
        public virtual ICollection<Fly_Order> Fly_Order { get; set; }
    }
}
