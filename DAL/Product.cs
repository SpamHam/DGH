//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
           this.OrderLines = new HashSet<OrderLine>();
       }
    
        public int id { get; set; }
        public string name { get; set; }
        public string productNumber { get; set; }
        public string color { get; set; }
        public int stock { get; set; }
        public decimal salesPrice { get; set; }
    
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
