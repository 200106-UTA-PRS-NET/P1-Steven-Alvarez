using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IPizza
    {

        public Pizza MapPizzaByIDs(int crustID, int sauceID, int cheeseID, int sizeID, int toppingID);

        public decimal GetPriceByPizza(Pizza p);
        public decimal GetPriceByID(int id);
        public Pizza GetPizzaById(int id);
        public List<Cheese> GetCheeseTypes();
        public List<Sauce> GetSauceTypes();
        public List<Crust> GetCrustTypes();
        public List<Size> GetSizeTypes();
        public List<Toppings> GetToppingTypes();

    }   
}
