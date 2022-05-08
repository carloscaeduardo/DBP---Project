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
        public ActionResult AllProducts()
        {
            TechSupportEntities context = new TechSupportEntities();
            List<Product> products = context.Products.ToList();
            return View(products);
        }
    }
}