using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaBox.Web.Models
{
    public class StoreOHistoryViewModel
    {
        public DateTime OrderDate { get; set; }
        public List<Pizza> OrderedPizzas { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public decimal Subtotal { get; set; }
    }
}