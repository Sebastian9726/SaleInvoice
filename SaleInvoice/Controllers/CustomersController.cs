using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleInvoice.Models;
using SaleInvoice.Models.Answer;
using SaleInvoice.Models.Request;

namespace SaleInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
      
        // GET: api/Customers
        [HttpGet]
        public IActionResult Get()
        {
            Answer oAnswer = new Answer();
            oAnswer.Exito = 0;
            try
            {

                using (BillingContext db = new BillingContext())
                {
                    var lst = db.Customer.ToList();
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
        //Add customer
        [HttpPost]
        public IActionResult Add(CustomersRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {
                    Customer oCustemer = new Customer();
                    oCustemer.IdCard = oModel.IdCard;
                    oCustemer.NameCustomer = oModel.NameCustomer;
                    oCustemer.DateCustomer = DateTime.Now;
                    
                                        
                    db.Customer.Add(oCustemer);
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
        //Edit customer
        [HttpPut]
        public IActionResult Edit(CustomersRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {

                    Customer oCustemer = new Customer();
                    oCustemer.NameCustomer = oModel.NameCustomer;
                    db.Customer.Add(oCustemer);
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

        //Delete customer
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Answer oAnswer = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {
                    Customer oCustomer = db.Customer.Find(Id);
                    db.Remove(oCustomer);
                    db.SaveChanges();
                    oAnswer.Exito = 1;
                }


            }
            catch (Exception ex)
            {
                oAnswer.Mensaje = ex.Message;
            }
            return Ok(oAnswer);
        }

    }
}
