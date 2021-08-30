using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaleInvoice.Models
{
    public partial class Sold
    {
        public Sold()
        {
            ProductSold = new HashSet<ProductSold>();
        }

        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Registration { get; set; }
        public int IdSeller { get; set; }
        public double? Total { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Seller IdSellerNavigation { get; set; }
        public virtual ICollection<ProductSold> ProductSold { get; set; }
    }
}
