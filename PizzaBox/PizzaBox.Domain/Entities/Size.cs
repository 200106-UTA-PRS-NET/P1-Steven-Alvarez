using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Size
    {
        public Size()
        {
            Pizza = new HashSet<Pizza>();
        }
        public virtual ICollection<Pizza> Pizza { get; set; }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? Price { get; set; }


    }
}