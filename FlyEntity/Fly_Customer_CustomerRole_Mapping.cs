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
    
    public partial class Fly_Customer_CustomerRole_Mapping
    {
        public int CustomerMappingCustomerRoleID { get; set; }
        public int CustomerID { get; set; }
        public int CustomerRoleID { get; set; }
        public Nullable<System.DateTime> Creadedon { get; set; }
    
        public virtual Fly_Customer Fly_Customer { get; set; }
        public virtual Fly_CustomerRole Fly_CustomerRole { get; set; }
    }
}
