using PizzaBox.Storing.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Models
{
    public class UserDetails : AbstractUser
    {
        public bool Admin { get; set; }
        public List<OrderDetails> Orders { get; set; }
        public AddressDetails Address { get; set; }
        public UserDetails()
        {

            Address = new AddressDetails();

            this.Orders = new List<OrderDetails>();
        }
        public override string ToString()
        {
            return $"{this.FirstName}";
        }
    }
}
