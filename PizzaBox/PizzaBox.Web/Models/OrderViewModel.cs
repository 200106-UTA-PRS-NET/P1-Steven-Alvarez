using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaBox.Web.Models
{
    public class OrderViewModel
    {
        public int StoreId { get; set; }
        public Dictionary<Pizza, decimal> Pizzas { get; set; }
        public decimal Subtotal { get; set; }
    }
}