using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IOrder
    {

        public void AddPizzaToOrder(Pizza p, decimal price);

        public List<Pizza> GetOrderedPizzas();

        public void SetCurrentPizza(Pizza p);

        public Pizza GetCurrentPizza();

        public bool SubmitOrder(int userID, int storeID);

        public List<Order> GetStoreOrderHistoryById(int storeID);

        public List<Pizza> GetOrderedPizzasByOrderId(int orderID);

        public List<Order> GetUserOrderHistoryById(int userID);

        public void ClearOrder();
    }
}
