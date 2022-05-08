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
        public ActionResult AllStates(int sortBy = 0, bool isDesc = false)
        {
            TechSupportEntities context = new TechSupportEntities();
            List<State> states;

            switch (sortBy)
            {
                case 1:
                    {
                        if (isDesc)
                            states = context.States.OrderByDescending(s => s.StateCode).ToList();
                        else
                            states = context.States.OrderBy(s => s.StateCode).ToList();
                        break;
                    }
                case 2:
                    {
                        if (isDesc)
                            states = context.States.OrderByDescending(s => s.StateName).ToList();
                        else
                            states = context.States.OrderBy(s => s.StateName).ToList();
                        break;
                    }

                case 3:
                    {
                        if (isDesc)
                            states = context.States.OrderByDescending(s => s.FirstZipCode).ToList();
                        else
                            states = context.States.OrderBy(s => s.FirstZipCode).ToList();
                        break;
                    }

                case 0:
                default:
                    {
                        if (isDesc)
                            states = context.States.OrderByDescending(s => s.LastZipCode).ToList();
                        else
                            states = context.States.OrderBy(s => s.LastZipCode).ToList();
                        break;
                    }

            }

            return View(states);
        }
    }
}