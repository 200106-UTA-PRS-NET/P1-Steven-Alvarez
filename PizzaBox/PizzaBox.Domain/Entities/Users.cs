using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Order>();

        }
        public virtual ICollection<Order> Orders { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}