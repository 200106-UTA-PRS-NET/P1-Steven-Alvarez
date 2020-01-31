using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Toppings
    {
        public Toppings()
        {
            PizzasTopping = new HashSet<Pizza>();

        }
        public virtual ICollection<Pizza> PizzasTopping { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }


    }
}