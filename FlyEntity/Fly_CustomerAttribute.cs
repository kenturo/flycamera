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
    
    public partial class Fly_CustomerAttribute
    {
        public int CustomerAttributeId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> MobilePhone { get; set; }
    
        public virtual Fly_Country Fly_Country { get; set; }
        public virtual Fly_Customer Fly_Customer { get; set; }
    }
}
