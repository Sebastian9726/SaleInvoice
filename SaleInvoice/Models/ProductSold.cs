using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaleInvoice.Models
{
    public partial class ProductSold
    {
        public int Id { get; set; }
        public int IdProductSold { get; set; }
        public double UnitPrice { get; set; }
        public double? TotalProduct { get; set; }
        public int? Aumont { get; set; }
        public DateTime? RegisterSold { get; set; }

        public virtual Sold IdProductSoldNavigation { get; set; }
    }
}
