using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleInvoice.Models.Request;

namespace SaleInvoice.Models.Request
{
    public class SoldRequest
    {

        public List<ProductsSolds> Products { get; set; }

        public int Id { get; set; }
        public int IdCustomers { get; set; }
        public  int  IdSeller{ get; set; }
       

    }
}
