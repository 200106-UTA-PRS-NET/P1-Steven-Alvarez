using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IStore
    {

        public IEnumerable<Store> GetStores();



        public IEnumerable<Pizza> GetStorePizzasById(int id);

        public Store GetStoreById(int id);

        public void SetCurrStore(Store s);

        public Store GetCurrStore();

        public DateTime? GetLastOrderDate(int storeID, int userID);


    }
}
