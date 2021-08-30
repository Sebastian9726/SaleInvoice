using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleInvoice.Models;
using SaleInvoice.Models.Answer;
using SaleInvoice.Models.Request;

namespace SaleInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        // GET: api/Sells
        [HttpGet]
        public IActionResult Get()
        {
            Answer oAnswer = new Answer();
            oAnswer.Exito = 0;
            try
            {

                using (BillingContext db = new BillingContext())
                {
                    var lst = db.Seller.ToList();
                    oAnswer.Exito = 1;
                    oAnswer.Data = lst;

                }
            }
            catch (Exception ex)
            {
                oAnswer.Mensaje = ex.Message;
            }
            return Ok(oAnswer);
        }
        //Add Seller
        [HttpPost]
        public IActionResult Add(SellerRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {

                    Seller oSeller = new Seller();

                    oSeller.IdCard = oModel.IdCard;
                    oSeller.NameSeller = oModel.NameSeller;
                 
                    db.Seller.Add(oSeller);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

    }
}
