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
                        
                        
                            var total =0.0;
                        foreach (var modelConceptProduct in oModel.Products)
                            {

                                //Actualizacion tabla ProductSold
                                ProductSold productSold = new ProductSold();
                                Sold oldSold = db.Sold.Find(oSell.Id);
                                
                                var OldProductValue = db.Product.Find(modelConceptProduct.IdProduct);
                                productSold.IdProductSold = oSell.Id;
                                productSold.RegisterSold = oSell.Registration;
                                productSold.UnitPrice = OldProductValue.UnitPrice;
                                productSold.Aumont = modelConceptProduct.Amount;
                                productSold.TotalProduct = modelConceptProduct.Amount * OldProductValue.UnitPrice;
                                OldProductValue.Stock = OldProductValue.Stock - modelConceptProduct.Amount;
                                total += (modelConceptProduct.Amount * OldProductValue.UnitPrice);
                                db.Entry(OldProductValue).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                                db.SaveChanges();
                            }


                               ;
                        oSell.Total = total;
                            db.Sold.Add(oSell);
                        db.SaveChanges();



                        transaction.Commit();
                      

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
