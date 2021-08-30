using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaleInvoice.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Sold = new HashSet<Sold>();
        }

        public int IdSeller { get; set; }
        public string IdCard { get; set; }
        public string NameSeller { get; set; }

        public virtual ICollection<Sold> Sold { get; set; }
    }
}
