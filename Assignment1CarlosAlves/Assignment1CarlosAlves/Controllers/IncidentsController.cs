using Assignment1CarlosAlves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1CarlosAlves.Controllers
{
    public class IncidentsController : Controller
    {
        // GET: Incidents
        public ActionResult AllIncidents()
        {
            TechSupportEntities context = new TechSupportEntities();
            List<Incident> incidents = context.Incidents.ToList();
            return View(incidents);
        }
    }
}