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


        Users currUser;

        Store currStore;



        public OrderController(IOrder repo, IPizza pizzaRepo, IStore storeRepo, IUser userRepo)

        {

            _repo = repo;

            _pizzaRepo = pizzaRepo;

            _storeRepo = storeRepo;

            _userRepo = userRepo;

            currUser = _userRepo.GetCurrUser();

            currStore = _storeRepo.GetCurrStore();
        }



        public IActionResult OrderView()
        {

            if (currUser == null)
            {

                return RedirectToAction("Login", "User");

            }


            var pizzas = _repo.GetOrderedPizzas().ToList();

            OrderViewModel orderVM = new OrderViewModel()
            {
                Pizzas = new Dictionary<Pizza, decimal>(),
                StoreId = _storeRepo.GetCurrStore().StoreId
            };

            decimal subtotal = 0;
            foreach (Pizza p in pizzas)
            {
                if (p.Name == null || p.Name == "")
                {
                    p.Name = "CustomPizza";
                }
                decimal price = _pizzaRepo.GetPriceByPizza(p);
                subtotal += price;
                orderVM.Pizzas.Add(p, price);
            }
            orderVM.Subtotal = subtotal;
            return View(orderVM);
        }

        public IActionResult SubmitOrder()
        {

            if (currUser == null)

            {

                return RedirectToAction("Login", "User");
            }


            if (_repo.SubmitOrder(_userRepo.GetCurrUser().Id, _storeRepo.GetCurrStore().StoreId))

            {

                // ORDER SUBMITTED

                _repo.ClearOrder();

                return RedirectToAction("Menu", "Store", new { id = _storeRepo.GetCurrStore().StoreId });

            }

            else

            {

                // ORDER NOT SUBMITTED

                _repo.ClearOrder();

                return RedirectToAction("Menu", "StoreController", _storeRepo.GetCurrStore().StoreId);

            }
        }

    }

}