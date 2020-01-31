using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Crust
    {
        public Crust()
        {
            Pizzas = new HashSet<Pizza>();

        }
        public virtual ICollection<Pizza> Pizzas { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

    }

}