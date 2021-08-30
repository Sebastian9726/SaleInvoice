using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleInvoice.Models.Request;

namespace SaleInvoice.Services
{
    public interface ISoldServices 
    {
        public void Add(SoldRequest oModel);
    }
}
