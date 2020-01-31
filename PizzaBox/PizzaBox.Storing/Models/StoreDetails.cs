using PizzaBox.Storing.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Models
{
    public partial class StoreDetails
    { 
        public StoreDetails()
        {
            Orders = new List<OrderDetails>();

            Address = new AddressDetails();
        }

        public string StoreName { get; set; }
        public AddressDetails Address { get; set; }
        // public UserModel User { get; set; }
        public List<OrderDetails> Orders { get; set; }

    }

}
