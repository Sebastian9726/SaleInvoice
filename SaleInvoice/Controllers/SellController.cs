using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleInvoice.Models;
using SaleInvoice.Models.Answer;
using SaleInvoice.Models.Request;
using SaleInvoice.Services;

namespace SaleInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private  ISoldServices _Sell;
       
        public SellController(ISoldServices Sell)
        {
            
            this._Sell = Sell;
        }

        // GET: api/Sell
        [HttpGet]
        public IActionResult Get()
        {
            Answer oAnswer = new Answer();
            oAnswer.Exito = 0;
            try
            {

                using (BillingContext db = new BillingContext())
                {
                    var lst = db.Sold.ToList();
                    // var query = from a in db.Sold where Reg in ctx.Saldos on a.id equals s.id select new ArticuloSaldo
                    //var lst2 = db.Sold.Where(a => DbFunctions.Register(a.fecha) == DbFunctions.TruncateTime(fecha)).ToList();

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
        //Add sell
        [HttpPost]
        public IActionResult Add(SoldRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {

                _Sell.Add(oModel);
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public IActionResult Edit(SoldRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {
                    Sold oSold = db.Sold.Find(oModel.Id);
                    oSold.IdCustomer = oModel.IdCustomers;
                    oSold.IdSeller = oModel.IdSeller;
                    db.Entry(oSold).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
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
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {
                    Sold oSold = db.Sold.Find(Id);
                    db.Remove(oSold);
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
