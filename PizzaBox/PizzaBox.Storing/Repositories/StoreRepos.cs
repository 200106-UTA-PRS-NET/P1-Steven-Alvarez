using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaBox.Storing.Models;
using PizzaBox.Domain;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Storing;
using PizzaBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
    public class StoreRepos : IStore
    {
        PizzaBoxDbContext db;
        public Store currStore;

        public StoreRepos()
        {
            db = new PizzaBoxDbContext();
        }


        public StoreRepos(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Pizza> GetStorePizzasById(int id)
        {
            var storePizzaIDs = db.StorePizzas.Where(sp => sp.StoreId == id).Select(sp => sp.PizzaId).ToList();

            var pizzas = db.Pizza
                .Include(o => o.Size)
                .Include(o => o.Crust)
                .Include(o => o.Cheese)
                .Include(o => o.Sauce)
                .Include(o => o.Topping)
                .Where(p => storePizzaIDs.Contains(p.Id)).ToList();


           /* foreach (Pizza p in pizzas)
            {
               // p.Crust = db.Crust.Where(c => c.Id == p.CrustId).Single();
               // p.Cheese = db.Cheeses.Where(c => c.Id == p.CheeseId).Single();
               // p.Sauce = db.Sauces.Where(c => c.Id == p.SauceId).Single();
                //p.Size = db.Size.Where(c => c.SizeId == p.SizeId).Single();
                //p.Topping = db.Topping.Where(c => c.Id == p.ToppingId).Single();
            } */
            return pizzas;
        }



        public Store GetStoreById(int id)
        {
            var query = db.Store.Where(s => s.StoreId == id).Single();
            return query;
        }

        public IEnumerable<Store> GetStores()
        {
            var query = db.Store.Select(s => s);
            return query;
        }
        public void SetCurrStore(Store s)
        {
            currStore = s;

        }

        public Store GetCurrStore()
        {
            return currStore;
        }


        public DateTime? GetLastOrderDate(int storeID, int userID)

        {

            try

            {

                var lastOrder = db.Order.Where(o => o.StoreId == storeID && o.UserId == userID)

                    .OrderByDescending(o => o.OrderDate)

                    .FirstOrDefault();



                return lastOrder.OrderDate.Value;

            }
            catch (InvalidOperationException)
            {

                return null;

            }
        }
    }
}