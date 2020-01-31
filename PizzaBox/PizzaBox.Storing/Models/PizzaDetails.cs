using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain;
using PizzaBox.Domain.Entities;

namespace PizzaBox.Storing.Models
{
    public class PizzaDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public Cheese Cheese { get; set; }
        public Sauce Sauce { get; set; }
        public Size Size { get; set; }
        public Crust Crust { get; set; }
        public Toppings Topping { get; set; }
    }
}