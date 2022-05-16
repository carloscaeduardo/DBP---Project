﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1CarlosAlves.Models
{
    public class UpsertIncidentsModel
    {
        public Incident Incident { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }
    }
}