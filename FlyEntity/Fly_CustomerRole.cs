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
    
    public partial class Fly_CustomerRole
    {
        public Fly_CustomerRole()
        {
            this.Fly_Customer_CustomerRole_Mapping = new HashSet<Fly_Customer_CustomerRole_Mapping>();
            this.Fly_CustomerRole_Discount_Mapping = new HashSet<Fly_CustomerRole_Discount_Mapping>();
            this.Fly_CustomerRole_ProductPrice = new HashSet<Fly_CustomerRole_ProductPrice>();
        }
    
        public int CustomerRoleID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> FreeShipping { get; set; }
        public Nullable<bool> TaxExempt { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Selected { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual ICollection<Fly_Customer_CustomerRole_Mapping> Fly_Customer_CustomerRole_Mapping { get; set; }
        public virtual ICollection<Fly_CustomerRole_Discount_Mapping> Fly_CustomerRole_Discount_Mapping { get; set; }
        public virtual ICollection<Fly_CustomerRole_ProductPrice> Fly_CustomerRole_ProductPrice { get; set; }
    }
}