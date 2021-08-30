using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SaleInvoice.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sold = new HashSet<Sold>();
        }

        public int IdCustomer { get; set; }
        public int? IdCard { get; set; }
        public string NameCustomer { get; set; }
        public DateTime? DateCustomer { get; set; }
        public int? AgeD { get; set; }

        public virtual ICollection<Sold> Sold { get; set; }
    }
}
