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
    public class ProductsController : ControllerBase
    {
        

        // GET: api/Products
       
        [HttpGet]
        public IActionResult Get()
        {
            Answer oAnswer = new Answer();
            oAnswer.Exito = 0;
            try
            {

                using (BillingContext db = new BillingContext())
                {
                    var lst = db.Product.ToList();
                  var lst2 = db.Product.Where(x => x.Stock <= 5).ToList();
                    
                  
                    


                    oAnswer.Exito = 1;
                    oAnswer.Data = lst;
                    oAnswer.Data2 = lst2;
                  

                }
            }
            catch (Exception ex)
            {
                oAnswer.Mensaje = ex.Message;
            }
            return Ok(oAnswer);
        }
        //Add product
        [HttpPost]
        public IActionResult Add(ProductRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {

                    Product oProduct = new Product();
                    
                    oProduct.NameProduct = oModel.NameProduct;
                    oProduct.DescriptionProducto = oModel.DescriptionProducto;
                    oProduct.Active = oModel.Active;
                    oProduct.Stock = oModel.Stock;
                    db.Product.Add(oProduct);
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
        //Editar Producto
        [HttpPut]
        public IActionResult Edit(ProductRequest oModel)
        {
            Answer oRespuesta = new Answer();

            try
            {
                using (BillingContext db = new BillingContext())
                {
                    Product oProducto = db.Product.Find(oModel.Id);
                    oProducto.NameProduct = oModel.NameProduct;
                    oProducto.DescriptionProducto = oModel.DescriptionProducto;
                    oProducto.UnitPrice = oModel.UnitPrice;
                    oProducto.Stock = oModel.Stock;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
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
    
    //Eliminar Producto
    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        Answer oRespuesta = new Answer();

        try
        {
            using (BillingContext db = new BillingContext())
            {
                Product oProducto = db.Product.Find(Id);
                    db.Remove(oProducto);
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


