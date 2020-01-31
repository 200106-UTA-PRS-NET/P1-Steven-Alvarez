using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Entities;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Web.Models;


namespace PizzaBox.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _repo;

        private readonly IPizza _pizzaRepo;

        private readonly IStore _storeRepo;

        private readonly IUser _userRepo;



        public OrderController(IOrder repo, IPizza pizzaRepo, IStore storeRepo, IUser userRepo)

        {

            _repo = repo;

            _pizzaRepo = pizzaRepo;

            _storeRepo = storeRepo;

            _userRepo = userRepo;

        }



        public IActionResult ViewOrder()
        {
            var pizzas = _repo.GetOrderedPizzas().ToList();

            OrderViewModel ovm = new OrderViewModel()
            {
                Pizzas = new Dictionary<Pizza, decimal>()
            };

            decimal subtotal = 0;
            foreach (Pizza p in pizzas)
            {
                if (p.Name == null || p.Name == "")
                {
                    p.Name = "Custom";
                }
                decimal price = _pizzaRepo.GetPriceByPizza(p);
                subtotal += price;
                ovm.Pizzas.Add(p, price);
            }
            ovm.Subtotal = subtotal;
            return View(ovm);
        }

        public string SubmitOrder()
        {
            if (_repo.SubmitOrder(_userRepo.GetCurrUser().Id, _storeRepo.GetCurrStore().StoreId))
            {
                return "Order Submitted";
            }
            else
            {
                return "Oh NO!! Something has gone wrong";
            }
        }
    }

}