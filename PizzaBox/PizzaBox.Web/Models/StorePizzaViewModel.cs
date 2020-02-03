﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaBox.Web.Models
{
    public class StorePizzaViewModel
    {
        public int StoreID { get; set; }
        public int PizzaID { get; set; }
        public string StoreName { get; set; }
        public string PizzaName { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string Cheese { get; set; }
        public List<string> Toppings { get; set; }
        public string Topping { get; set; }
        public decimal Price { get; set; }
        public DateTime? WaitTime { get; set; }
    }

}