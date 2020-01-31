using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Store
    {
        public Store()
        {

            Order = new HashSet<Order>();
            StorePizzas = new HashSet<StoreP>();
        }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<StoreP> StorePizzas { get; set; }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }


        public virtual Address Address { get; set; }
        public virtual Users User { get; set; }

    }
}