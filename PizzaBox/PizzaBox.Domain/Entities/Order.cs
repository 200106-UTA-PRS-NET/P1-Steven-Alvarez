using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderP>();
        }
        public virtual ICollection<OrderP> OrderPizza { get; set; }


        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? OrderDate { get; set; }
       // public bool? Active { get; set; }
        public virtual Store Store { get; set; }
        public virtual Users User { get; set; }
    }
}