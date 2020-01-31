using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain;
using PizzaBox.Domain.Entities;

namespace PizzaBox.Storing.Models
{
    public class ToppingDetails
    {
        public List<Crust> Crusts { get; set; }
        public List<Cheese> Cheeses { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Toppings> Toppings { get; set; }
        public List<Sauce> Sauces { get; set; }
    }
}
