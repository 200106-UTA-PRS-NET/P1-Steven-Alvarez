using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PizzaBox.Domain.Entities
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizzas = new HashSet<OrderP>();

            StorePizzas = new HashSet<StoreP>();
        }
        public virtual ICollection<OrderP> OrderPizzas { get; set; }
        public virtual ICollection<StoreP> StorePizzas { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SizeId { get; set; }
        public int? ToppingId { get; set; }
        public int? CrustId { get; set; }
        public int? CheeseId { get; set; }
        public int? SauceId { get; set; }
        public virtual Size Size { get; set; }
        public virtual Toppings Topping { get; set; }
        public virtual Cheese Cheese { get; set; }
        public virtual Crust Crust { get; set; }
        public virtual Sauce Sauce { get; set; }

    }

}