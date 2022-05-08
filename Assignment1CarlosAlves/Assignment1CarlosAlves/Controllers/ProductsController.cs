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
    }
}