using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleInvoice.Models.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProducto { get; set; }
        public int Active { get; set; }
        public int Stock { get; set; }

          public double UnitPrice { get; set; }
      
    }
}
