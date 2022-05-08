using Assignment1CarlosAlves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1CarlosAlves.Controllers
{
    public class TechniciansController : Controller
    {
        // GET: Technicians
        public ActionResult AllTechnicians()
        {
            TechSupportEntities context = new TechSupportEntities();
            List<Technician> technicians = context.Technicians.ToList();
            return View(technicians);
        }
    }
}