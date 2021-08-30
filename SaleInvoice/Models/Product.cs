using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaleInvoice.Models
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProducto { get; set; }
        public int? Active { get; set; }
        public int? Stock { get; set; }
        public double UnitPrice { get; set; }
    }
}
