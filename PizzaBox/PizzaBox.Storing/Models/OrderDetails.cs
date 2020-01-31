using System;
using System.Collections.Generic;
using PizzaBox.Storing.Abstracts;


namespace PizzaBox.Storing.Models
{ 
    public class OrderDetails
    {
        public OrderDetails()
        {
            Pizzas = new List<PizzaDetails>();

            User = new UserDetails();
        }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }


        public UserDetails User { get; set; }
        public List<PizzaDetails> Pizzas { get; set; }
    }
}