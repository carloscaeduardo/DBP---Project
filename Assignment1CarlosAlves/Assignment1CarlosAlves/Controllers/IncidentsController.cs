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

        public ActionResult AllIncidents(string id, int sortBy=0, bool isDesc = false)
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
            if (!string.IsNullOrWhiteSpace(id))
            {
                id = id.Trim().ToLower();
                int incidentsLookUp = 0;


                //in case id is an integer
                if (int.TryParse(id, out incidentsLookUp))
                {
                    Console.WriteLine(id);
                    incidents = incidents.Where(i =>
                               i.IncidentID == incidentsLookUp
                               ).ToList();


                }
                else // if id does not parse
                {
                    incidents = incidents.Where(i =>
                     i.Title.ToLower().Contains(id) ||
                      i.Description.ToLower().Contains(id)
                     
                      ).ToList();
                }


            }

            return View(incidents);
        }


        [HttpGet]
        public ActionResult UpsertIncidents(string id)
        {
            TechSupportEntities context = new TechSupportEntities();
            Incident incident = context.Incidents.Where(i => i.IncidentID.ToString() == id).FirstOrDefault();
            List<Customer> customers = context.Customers.ToList();
            List<Product> products = context.Products.ToList();
            List<Technician> technicians = context.Technicians.ToList();

            UpsertIncidentsModel viewModel = new UpsertIncidentsModel()
            {
                Incident = incident,
                Customers = customers,
                Products = products,
                Technicians = technicians,


            };
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult UpsertIncidents(UpsertIncidentsModel model)
        {
            Incident newIncident = model.Incident;
            TechSupportEntities context = new TechSupportEntities();
            try
            {
                if(context.Incidents.Where(i => i.IncidentID == newIncident.IncidentID).Count() > 0 )
                {
                    var incidentToSave = context.Incidents.Where(i => i.IncidentID == newIncident.IncidentID).FirstOrDefault();
                    incidentToSave.Title = newIncident.Title;
                    incidentToSave.Description = newIncident.Description;
                    incidentToSave.DateOpened = newIncident.DateOpened;
                    incidentToSave.DateClosed = newIncident.DateClosed;
                    incidentToSave.ProductCode = newIncident.ProductCode;
                    incidentToSave.TechID = newIncident.TechID;
                    incidentToSave.CustomerID = newIncident.CustomerID;
                    
                    
                }
                else
                {
                    context.Incidents.Add(newIncident);
                }
                context.SaveChanges();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("AllIncidents");
        }

    }

   


}