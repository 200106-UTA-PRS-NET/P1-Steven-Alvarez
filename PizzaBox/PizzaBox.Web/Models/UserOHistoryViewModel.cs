using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Web.Models
{
    public class UserOHistoryViewModel
    {

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Subtotal { get; set; }

        public string StoreName { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
