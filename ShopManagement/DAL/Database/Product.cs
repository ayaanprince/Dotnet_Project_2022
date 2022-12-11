//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Deliveries = new HashSet<Delivery>();
            this.Records = new HashSet<Record>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoriesId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
