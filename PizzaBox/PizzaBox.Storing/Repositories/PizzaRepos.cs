using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Storing.Models;
using PizzaBox.Domain.Entities;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaRepos : IPizza
    {
        PizzaBoxDbContext db;

        public PizzaRepos()
        {
            db = new PizzaBoxDbContext();

        }

        public PizzaRepos(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public decimal GetPriceByID(int id)
        {
            var pizza = db.Pizza.Where(p => p.Id == id).Single();

            decimal crust = db.Crust.Where(c => c.Id == pizza.CrustId).Select(c => c.Price).Single().Value;
            decimal sauce = db.Sauces.Where(s => s.Id == pizza.SauceId).Select(s => s.Price).Single().Value;
            decimal cheese = db.Cheeses.Where(c => c.Id == pizza.CheeseId).Select(c => c.Price).Single().Value;
            decimal size = db.Size.Where(s => s.SizeId == pizza.SizeId).Select(s => s.Price).Single().Value;


            return crust + sauce + cheese + size;
        }

        public decimal GetPriceByPizza(Pizza p)
        {
            return p.Cheese.Price.Value + p.Sauce.Price.Value + p.Crust.Price.Value + p.Size.Price.Value;

        }

        public Pizza GetPizzaById(int id)
        {
            var query = db.Pizza.Where(p => p.Id == id).Single();
            return query;
        }

        public List<Toppings> GetToppingTypes()
        {
            return db.Topping.Select(c => c).ToList();
        }
        public List<Sauce> GetSauceTypes()
        {
            return db.Sauces.Select(c => c).ToList();
        }

        public List<Cheese> GetCheeseTypes()
        {
            return db.Cheeses.Select(c => c).ToList();
        }

        public List<Crust> GetCrustTypes()
        {
            return db.Crust.Select(c => c).ToList();
        }


        public List<Size> GetSizeTypes()
        {
            return db.Size.Select(c => c).ToList();
        }

        public Pizza MapPizzaByIDs(int crustID, int sauceID, int cheeseID, int sizeID, int toppingID)

        {
            return new Pizza()
            {
                Cheese = db.Cheeses.Where(c => c.Id == cheeseID).Single(),
                Sauce = db.Sauces.Where(s => s.Id == sauceID).Single(),
                Crust = db.Crust.Where(c => c.Id == crustID).Single(),
                Size = db.Size.Where(s => s.SizeId == sizeID).Single(),
                Topping = db.Topping.Where(t => t.Id == toppingID).Single(),
            };

        }
    }
}