using Assignment1CarlosAlves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1CarlosAlves.Controllers
{
    public class StatesController : Controller
    {
        // GET: States
        public ActionResult AllStates()
        {
            TechSupportEntities context = new TechSupportEntities();
            List<State> states = context.States.ToList();
            return View(states);
        }
    }
}