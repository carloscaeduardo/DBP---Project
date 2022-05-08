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
        public ActionResult AllTechnicians(int sortBy=0, bool isDesc = false)
        {
            TechSupportEntities context = new TechSupportEntities();
            List<Technician> technicians;
            switch (sortBy) { 
                 case 1:
                        {
                            if (isDesc)
                                technicians = context.Technicians.OrderByDescending(t => t.TechID).ToList();
                            else
                                technicians = context.Technicians.OrderBy(t => t.TechID).ToList();
                            break;
                        }
                case 2:
                    {
                        if (isDesc)
                            technicians = context.Technicians.OrderByDescending(t => t.Name).ToList();
                        else
                            technicians = context.Technicians.OrderBy(t => t.Name).ToList();
                        break;
                    }
                case 3:
                    {
                        if (isDesc)
                            technicians = context.Technicians.OrderByDescending(t => t.Email).ToList();
                        else
                            technicians = context.Technicians.OrderBy(t => t.Email).ToList();
                        break;
                    }
                case 0:
                default:
                    {
                        if (isDesc)
                            technicians = context.Technicians.OrderByDescending(t => t.Phone).ToList();
                        else
                            technicians = context.Technicians.OrderBy(t => t.Phone).ToList();
                        break;
                    }


            }

            return View(technicians);
        }
    }
}