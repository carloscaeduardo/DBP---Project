using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1CarlosAlves.Models
{
    public class UpsertCustomerModel
    {
        public Customer Customer {get; set ;}
        public List<State> States {get; set;}
    }
}