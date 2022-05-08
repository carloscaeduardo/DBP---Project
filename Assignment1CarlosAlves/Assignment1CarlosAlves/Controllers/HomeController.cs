using Assignment1CarlosAlves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1CarlosAlves.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TechSupportEntities context = new TechSupportEntities();

            List<Customer> allCustomers = context.Customers.ToList();

            return View(allCustomers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}