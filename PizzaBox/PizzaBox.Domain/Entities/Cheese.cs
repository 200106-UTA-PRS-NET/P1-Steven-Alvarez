﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Entities
{
    public partial class Cheese
    {
        public Cheese()
        {
            Pizzas = new HashSet<Pizza>();

        }
        public virtual ICollection<Pizza> Pizzas { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

    }
}
