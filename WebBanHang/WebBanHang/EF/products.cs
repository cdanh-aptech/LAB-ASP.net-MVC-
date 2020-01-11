//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanHang.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public products()
        {
            this.order_details = new HashSet<order_details>();
        }
    
        public int id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public Nullable<decimal> standard_cost { get; set; }
        public decimal list_price { get; set; }
        public Nullable<int> target_level { get; set; }
        public Nullable<int> reorder_level { get; set; }
        public Nullable<int> minimum_reorder_quantity { get; set; }
        public string quantity_per_unit { get; set; }
        public byte discontinued { get; set; }
        public string category { get; set; }
        public string image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details { get; set; }
    }
}
