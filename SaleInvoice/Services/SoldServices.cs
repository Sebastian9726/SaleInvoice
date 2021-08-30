using SaleInvoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleInvoice.Models.Request;

namespace SaleInvoice.Services
{
    public class SoldServices : ISoldServices
    {
        public void Add(SoldRequest oModel)
            {
            
                using (BillingContext db = new BillingContext())
                {

                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Sold oSell = new Sold();
                            oSell.IdSeller = oModel.IdSeller;
                            oSell.IdCustomer = oModel.IdCustomers;
                            oSell.Registration = DateTime.Now;
                            db.Sold.Add(oSell);
                            db.SaveChanges();
                            foreach (var modelConceptProduct in oModel.Products)
                            {

                                //Actualizacion tabla ProductSold
                                ProductSold productSold = new ProductSold();

                                var OldProductValue = db.Product.Find(modelConceptProduct.IdProduct);
                                productSold.IdProductSold = oSell.Id;
                                productSold.RegisterSold = oSell.Registration;
                                productSold.UnitPrice = OldProductValue.UnitPrice;
                                productSold.Aumont = modelConceptProduct.Amount;
                                productSold.TotalProduct = modelConceptProduct.Amount * OldProductValue.UnitPrice;
                                OldProductValue.Stock = OldProductValue.Stock - modelConceptProduct.Amount;
                                db.Entry(OldProductValue).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                                db.ProductSold.Add(productSold);
                                db.SaveChanges();
                            }
                            transaction.Commit();
                            //Oconcept.Total =;
                            ///faltaaa totaaaal
                            ///tottaaaaal
                            
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw new Exception("There are a Error");
                        }

                    }

                }


           

        }
    }
}
