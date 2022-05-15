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
        /// <summary>
        /// The view returns a list of all states
        /// </summary>
        /// <param name="id">The search term</param>
        /// <param name="sortBy">Integer. 0 = StateCode, 1 = stateName, 2 = first ZipCode, 3 = LastZip</param>
        /// <returns></returns>
        public ActionResult AllStates(string id, int sortBy = 0)
        {

            TechSupportEntities context = new TechSupportEntities();
            //List<State> states = context.States.OrderBy(s => s.StateName).ToList();
            List<State> states;

            switch (sortBy)
            {
                case 1:
                    {
                        //if (isDesc)
                        //    states = context.States.OrderByDescending(s => s.StateCode).ToList();
                        //else
                        states = context.States.OrderBy(s => s.StateName).ToList();
                        break;
                    }
                case 2:
                    {
                        //if (isDesc)
                        //    states = context.States.OrderByDescending(s => s.StateName).ToList();
                        //else
                        states = context.States.OrderBy(s => s.FirstZipCode).ToList();
                        break;
                    }

                case 3:
                    {
                        //if (isDesc)
                        //    states = context.States.OrderByDescending(s => s.FirstZipCode).ToList();
                        //else
                        states = context.States.OrderBy(s => s.LastZipCode).ToList();
                        break;
                    }

                case 0:
                default:
                    {
                        //if (isDesc)
                        //    states = context.States.OrderByDescending(s => s.LastZipCode).ToList();
                        //else
                        states = context.States.OrderBy(s => s.StateCode).ToList();
                        break;
                    }

            }
            //id is used as "searchTerm" parameter
            if (!string.IsNullOrWhiteSpace(id))
            {
                id = id.Trim().ToLower();
                int zipCodeLookup = 0;


                //in case id is an integer
                if (int.TryParse(id, out zipCodeLookup))
                {
                    Console.WriteLine(id);
                    states = states.Where(s =>
                               s.FirstZipCode == zipCodeLookup ||
                               s.LastZipCode == zipCodeLookup
                                ).ToList();
                }
                else // if id does not parse
                {
                    states = states.Where(s =>
                      s.StateCode.ToLower().Contains(id) ||
                      s.StateName.ToLower().Contains(id)
                      ).ToList();
                }


            }

            foreach (var state in states)
            {
                int numOfCustomers = state.Customers.Count();
            }

            return View(states);
        }

        [HttpGet]
        public ActionResult UpsertStates(string id)
        {
            //State state = new State();
            TechSupportEntities context = new TechSupportEntities();
            State state = context.States.Where(s => s.StateCode == id).FirstOrDefault();

            return View(state);
        }

        [HttpPost]
        public ActionResult UpsertStates(State newState)
        {
            TechSupportEntities context = new TechSupportEntities( );

            try
            {
                if (context.States.Where(s => s.StateCode == newState.StateCode).Count() > 0)
                {
                    var stateToSave = context.States.Where(s => s.StateCode == newState.StateCode).FirstOrDefault();
                    stateToSave.StateName = newState.StateName;
                    stateToSave.FirstZipCode = newState.FirstZipCode;
                    stateToSave.LastZipCode = newState.LastZipCode;
                }
                else{
                    context.States.Add(newState);
                }
             
                context.SaveChanges();

            }
            catch
            {
                //log the exception in the error log and send an automatic email to IT support
                //throw;
            }

            

             return RedirectToAction("AllStates");
        }
       

    }


}
