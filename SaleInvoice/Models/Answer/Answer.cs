using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleInvoice.Models.Answer
{
    public class Answer
    {
            public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
         public object Data2 { get; set; }

        public object Data3 { get; set; }

        public Answer()
        {
            this.Exito = 0;
        }
    }
}
