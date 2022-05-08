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

        public ActionResult AllIncidents(int sortBy=0, bool isDesc = false)
        {
            TechSupportEntities context = new TechSupportEntities();
            List<Incident> incidents;

            switch (sortBy)
            {
                case 1:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.Title).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.Title).ToList();
                        break;
                    }
                case 2:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.Description).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.Description).ToList();
                        break;
                    }

                case 3:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.DateOpened).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.DateOpened).ToList();
                        break;
                    }
                case 4:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.DateClosed).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.DateClosed).ToList();
                        break;
                    }
                case 5:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.ProductCode).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.ProductCode).ToList();
                        break;
                    }
                case 6:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.TechID).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.TechID).ToList();
                        break;
                    }


                case 0:
                default:
                    {
                        if (isDesc)
                            incidents = context.Incidents.OrderByDescending(i => i.IncidentID).ToList();
                        else
                            incidents = context.Incidents.OrderBy(i => i.IncidentID).ToList();
                    }
                    break;
            }

            return View(incidents);
        }
    }
}