using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PizzaBox.Web.Models
{
    public class PizzaViewModel
    {
        public string Name { get; set; }
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public Toppings Topping { get; set; }
        public Sauce Sauce { get; set; }
        public Cheese Cheese { get; set; }

        public decimal Price { get; set; }
    }
}