using System;
using System.Collections.Generic;


namespace PizzaBox.Domian.Entities
{
    public partial class Account
    {
        public Account()
        {
          //  User = new HashSet<Users>();

        }


        public int UserAccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

       // public virtual ICollection<Users> User { get; set; }
    }
}