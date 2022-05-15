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
        public ActionResult AllTechnicians(string id, int sortBy=0, bool isDesc = false)
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
            //id is used as "searchTerm" parameter
            if (!string.IsNullOrWhiteSpace(id))
            {
                id = id.Trim().ToLower();
                int TechnicianCodeLookUp = 0;


                //in case id is an integer
                if (int.TryParse(id, out TechnicianCodeLookUp))
                {
                    Console.WriteLine(id);
                    technicians = technicians.Where(t =>
                               t.TechID == TechnicianCodeLookUp
                               ).ToList();


                }
                else // if id does not parse
                {
                    technicians = technicians.Where(t =>
                      t.Name.ToLower().Contains(id) ||
                      t.Email.ToLower().Contains(id) ||
                      t.Phone.ToLower().Contains(id)
                      ).ToList();
                }


            }

            return View(technicians);
        }


        [HttpGet]
        public ActionResult UpsertTechnician(string id)
        {
            //State state = new State();
            TechSupportEntities context = new TechSupportEntities();
            Technician technician = context.Technicians.Where(t => t.TechID.ToString() == id).FirstOrDefault();

            return View(technician);
        }

        [HttpPost]
        public ActionResult UpsertTechnician(Technician newTechnician)
        {
            TechSupportEntities context = new TechSupportEntities();

            try
            {
                if (context.Technicians.Where(t => t.TechID == newTechnician.TechID).Count() > 0)
                {
                    var technicianToSave = context.Technicians.Where(t => t.TechID == newTechnician.TechID).FirstOrDefault();
                    technicianToSave.Name = newTechnician.Name;
                    technicianToSave.Email = newTechnician.Email;
                    technicianToSave.Phone = newTechnician.Phone;
                }
                else
                {
                    context.Technicians.Add(newTechnician);
                }

                context.SaveChanges();

            }
            catch
            {
                //log the exception in the error log and send an automatic email to IT support
                //throw;
            }
            return RedirectToAction("AllTechnicians");
        }

    }
}