using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Entities
{
    public partial class StoreP
    {
        public int StoreId { get; set; }
        public int PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Store Store { get; set; }
    }
}
