using Assignment1CarlosAlves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1CarlosAlves.Controllers
{   
    public class CustomersController : Controller
    {
        /// GET : Customers
        ///<summary>
        ///
        /// </summary>
        /// <param name="sortBy"> 0 = Id, 1 = Name, 2 = Email, 3 = State </param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public ActionResult AllCustomers(string id, int sortBy=0, bool isDesc=false)
        {
           
            TechSupportEntities context = new TechSupportEntities();
            List<Customer> allCustomers ;

            switch (sortBy)
            {
                case 1:
                    {
                        if (isDesc)
                            allCustomers = context.Customers.OrderByDescending(c => c.Name).ToList();
                        else
                            allCustomers = context.Customers.OrderBy(c => c.Name).ToList();
                            break;
                    }
                case 2:
                    {
                        if (isDesc)
                            allCustomers = context.Customers.OrderByDescending(c => c.Email).ToList();
                        else
                            allCustomers = context.Customers.OrderBy(c => c.Email).ToList();
                        break;
                    }
                case 3:
                    {
                        if (isDesc)
                            allCustomers = context.Customers.OrderByDescending(c => c.State).ToList();
                        else
                            allCustomers = context.Customers.OrderBy(c => c.State).ToList();
                        break;
                    }
               
                case 0:
                default:
                    if (isDesc)
                        allCustomers = context.Customers.OrderByDescending(c => c.CustomerID).ToList();
                    else
                        allCustomers = context.Customers.OrderBy(c => c.CustomerID).ToList();
                    break;
            }
            if (!string.IsNullOrWhiteSpace(id))
            {
                id = id.Trim().ToLower();
                allCustomers = allCustomers.Where(c =>
                       c.Name.ToLower().Contains(id) ||
                       c.Email.ToLower().Contains(id) ||
                       c.State.ToLower().Contains(id)
                     
                       ).ToList();

                
            }
            return View(allCustomers);

        }
    }
}