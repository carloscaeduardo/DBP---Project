using Assignment1CarlosAlves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1CarlosAlves.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult AllProducts(int sortBy = 0, bool isDesc = false)
        {
            TechSupportEntities context = new TechSupportEntities();
            List<Product> products;

            switch (sortBy)
            {
                case 1:
                    {
                        if (isDesc)
                            products = context.Products.OrderByDescending(p => p.ProductCode).ToList();
                        else
                            products = context.Products.OrderBy(p => p.ProductCode).ToList();
                        break;
                    }
                case 2:
                    {
                        if (isDesc)
                            products = context.Products.OrderByDescending(p => p.Name).ToList();
                        else
                            products = context.Products.OrderBy(p => p.Name).ToList();
                        break;
                    }

                case 3:
                    {
                        if (isDesc)
                            products = context.Products.OrderByDescending(p => p.Version).ToList();
                        else
                            products = context.Products.OrderBy(p => p.Version).ToList();
                        break;
                    }

                case 0:
                default:
                    {
                        if (isDesc)
                            products = context.Products.OrderByDescending(p => p.ReleaseDate).ToList();
                        else
                            products = context.Products.OrderBy(p => p.ReleaseDate).ToList();
                        break;
                    }

            }

            return View(products);
        }



        [HttpGet]
        public ActionResult UpsertProducts(string id)
        {
            //State state = new State();
            TechSupportEntities context = new TechSupportEntities();
            Product product = context.Products.Where(p => p.ProductCode == id).FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        public ActionResult UpsertProducts(Product newProduct)
        {
            TechSupportEntities context = new TechSupportEntities();

            try
            {
                if (context.Products.Where(p => p.ProductCode == newProduct.ProductCode).Count() > 0)
                {
                    var productToSave = context.Products.Where(p =>  p.ProductCode== newProduct.ProductCode).FirstOrDefault();
                    productToSave.ProductCode = newProduct.ProductCode;
                    productToSave.Name = newProduct.Name;
                    productToSave.Version = newProduct.Version;
                    productToSave.ReleaseDate = newProduct.ReleaseDate;

                }
                else
                {
                   
                    context.Products.Add(newProduct);
                }

                context.SaveChanges();

            }
            catch
            {
                //log the exception in the error log and send an automatic email to IT support
                //throw;
            }
            return RedirectToAction("AllProducts");
        }

    }

   


}