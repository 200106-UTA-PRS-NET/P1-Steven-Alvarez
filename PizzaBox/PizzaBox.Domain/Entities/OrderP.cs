using System;
using System.Collections.Generic;



namespace PizzaBox.Domain.Entities
{
    public partial class OrderP
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int? Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}