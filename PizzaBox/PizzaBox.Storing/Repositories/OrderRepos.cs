using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaBox.Domain.Entities;
using PizzaBox.Domain.Interfaces;



namespace PizzaBox.Storing.Repositories
{

    public class OrderRepos : IOrder

    {
        PizzaBoxDbContext db;

        static Dictionary<Pizza, decimal> orderedPizzas = new Dictionary<Pizza, decimal>();
        static Pizza currPizza = new Pizza();
        public OrderRepos()
        {
            db = new PizzaBoxDbContext();
        }

        public OrderRepos(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddPizzaToOrder(Pizza p, decimal price)
        {
            orderedPizzas.Add(p, price);
        }

        public List<Pizza> GetOrderedPizzas()
        {
            return new List<Pizza>(orderedPizzas.Keys);
        }

        public void SetCurrentPizza(Pizza p)
        {
            currPizza = p;
        }

        public Pizza GetCurrentPizza()
        {
            return currPizza;
        }

        public bool SubmitOrder(int userID, int storeID)
        {

            decimal subtotal = 0;
            foreach (decimal price in orderedPizzas.Values)
            {
                subtotal += price;
            }

            Order order = new Order()
            {
                UserId = userID,
                StoreId = storeID,
                TotalCost = subtotal
            };

            db.Order.Add(order);

            db.SaveChanges();
            int orderID = order.OrderId;

            Dictionary<Pizza, int> pizzaCount = new Dictionary<Pizza, int>();

            foreach (Pizza p in orderedPizzas.Keys)
            {
                Pizza pizzaOnlyIds = new Pizza()
                {
                    CrustId = p.Crust.Id,
                    CheeseId = p.Cheese.Id,
                    SauceId = p.Sauce.Id,
                    SizeId = p.Size.SizeId,
                    ToppingId = p.Topping.Id,
                };

                if (pizzaCount.ContainsKey(pizzaOnlyIds))
                {
                    pizzaCount[pizzaOnlyIds]++;
                }
                else
                {
                    pizzaCount.Add(pizzaOnlyIds, 1);
                }
            }

            foreach (var item in pizzaCount)
            {
                Pizza pizza = item.Key;

                int count = item.Value;

                bool hasDuplicate = db.Pizza.Any(p => (p.SauceId == pizza.SauceId &&
                    p.CrustId == pizza.CrustId &&
                    p.CheeseId == pizza.CheeseId &&
                    p.SizeId == pizza.SizeId) &&
                    p.ToppingId == pizza.ToppingId 
                    // use 'and'  to add more toppings
                    );

                if (!hasDuplicate)
                {
                    db.Pizza.Add(pizza);
                    db.SaveChanges();
                    int newPizzaID = pizza.Id;

                    db.OrderPizza.Add(new OrderP()
                    {
                        OrderId = orderID,
                        PizzaId = newPizzaID,
                        Count = count
                    });

                    db.SaveChanges();
                }
                else
                {
                    int dupPizzaID = db.Pizza.Where(p => (p.SauceId == pizza.SauceId &&

                        p.CrustId == pizza.CrustId &&

                        p.CheeseId == pizza.CheeseId &&

                        p.SizeId == pizza.SizeId) &&

                        p.ToppingId == pizza.ToppingId && p.ToppingId == pizza.ToppingId).

                        Select(p => p.Id).FirstOrDefault();

                    db.OrderPizza.Add(new OrderP()
                    {
                        OrderId = orderID,
                        PizzaId = dupPizzaID,
                        Count = count
                    });
                    db.SaveChanges();
                }
            }
            return true;
        }



        public List<Order> GetStoreOrderHistoryById(int storeID)

        {

            var query = db.Order.Where(o => o.StoreId == storeID);



            return query.ToList();

        }

        public List<Pizza> GetOrderedPizzasByOrderId(int orderID)
        {
            var query = from p in db.Pizza

                        from op in db.OrderPizza

                        where op.OrderId == orderID

                        select p;

            return query.ToList();
        }
        public List<Order> GetUserOrderHistoryById(int userID)

        {

            var query = db.Order.Where(o => o.UserId == userID);



            return query.ToList();

        }



        public void ClearOrder()

        {

            orderedPizzas.Clear();

            currPizza = null;

        }
    }
}