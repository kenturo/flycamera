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
    
    public partial class Fly_RelatedProduct
    {
        public int RelatedProductID { get; set; }
        public Nullable<int> ProductID1 { get; set; }
        public Nullable<int> ProductID2 { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    
        public virtual Fly_Product Fly_Product { get; set; }
    }
}
