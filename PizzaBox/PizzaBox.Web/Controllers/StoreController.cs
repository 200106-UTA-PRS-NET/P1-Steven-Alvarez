using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain;
using PizzaBox.Domain.Entities;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Web.Models;



namespace PizzaBox.Web.Controllers
{
    public class StoreController : Controller
    {
        Users currUser = new Users();


        private readonly IUser _uR;
        private readonly IStore _sR;
        private readonly IPizza _pR;
        private readonly IOrder _orderRepo;



        public StoreController(IUser userRepo, IStore storeRepo, IPizza pizzaRepo, IOrder orderRepo)

        {
            _uR = userRepo;
            _sR = storeRepo;
            _pR = pizzaRepo;
            _orderRepo = orderRepo;

        }

        public IActionResult Index()
        {
            var stores = _sR.GetStores();

            List<StoreViewModel> storeVM = new List<StoreViewModel>();

            foreach (var item in stores)
            {
                StoreViewModel store = new StoreViewModel()
                {
                    Name = item.StoreName,

                    Id = item.StoreId
                };
                storeVM.Add(store);
            }
            return View(storeVM);
        }
        public IActionResult Menu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store store = _sR.GetStoreById(id.Value);

            _sR.SetCurrStore(store);

            var pizzas = _sR.GetStorePizzasById(id.Value);

            List<StorePizzaViewModel> spVM = new List<StorePizzaViewModel>();

            foreach (var p in pizzas)
            {
                StorePizzaViewModel pizza = new StorePizzaViewModel()
                {

                    StoreID = id.Value,
                    PizzaID = p.Id,

                    StoreName = _sR.GetStoreById(id.Value).StoreName,
                    PizzaName = p.Name,
                    Crust = p.Crust.Name,
                    Sauce = p.Sauce.Name,
                    Cheese = p.Cheese.Name,
                    Toppings = new List<String>() { p.Topping.Name }, //Add more toppings later
                    Price = _pR.GetPriceByID(p.Id)
                };
                spVM.Add(pizza);
            }
            return View(spVM);
        }

        public IActionResult Custom()
        {
            Dictionary<Toppings, bool> top = new Dictionary<Toppings, bool>();

            foreach (var topping in _pR.GetToppingTypes())
            {
                top.Add(topping, false);
            }

            /*if (currUser == null)
            {
                return RedirectToAction("Login", "User");
            }
            */

            CustomPizzaViewModel customPizzaModel = new CustomPizzaViewModel()
            {
                SelectedCheeseId = 1,
                SelectedCrustId = 1,
                SelectedSauceId = 1,
                SelectedSizeId = 1,
                SelectedToppingId = 1,
            };

            ViewData["cheeses"] = _pR.GetCheeseTypes();
            ViewData["sauces"] = _pR.GetSauceTypes();
            ViewData["crusts"] = _pR.GetCrustTypes();
            ViewData["sizes"] = _pR.GetSizeTypes();
            ViewData["toppings"] = _pR.GetToppingTypes();

            return View(customPizzaModel);
        }

        [HttpGet]
        public IActionResult ConfirmPizza(CustomPizzaViewModel C)
        {
            Pizza p = _pR.MapPizzaByIDs(C.SelectedCrustId, C.SelectedSauceId, C.SelectedCheeseId, C.SelectedSizeId, C.SelectedToppingId);
            _orderRepo.SetCurrentPizza(p);
            PizzaViewModel pizzaVM = new PizzaViewModel()
            {
                Cheese = p.Cheese,
                Sauce = p.Sauce,
                Size = p.Size,
                Crust = p.Crust,
                Topping = p.Topping,
                Price = _pR.GetPriceByPizza(p)
            };
            return View(pizzaVM);
        }

        [HttpPost]
        public IActionResult ConfirmPizza(PizzaViewModel pizzaVM)
        {
            Pizza p = _orderRepo.GetCurrentPizza();
            _orderRepo.AddPizzaToOrder(p, _pR.GetPriceByPizza(p));

            return RedirectToAction("ViewOrder", "Order");
        }

        // Displays store order history
        public IActionResult OrderHistory(int? id)
        {
            List<Order> orders = _orderRepo.GetStoreOrderHistoryById(id.Value);

            List<StoreOHistoryViewModel> storeOrdersVM = new List<StoreOHistoryViewModel>();

            foreach (var item in orders)
            {
                StoreOHistoryViewModel sOHVM = new StoreOHistoryViewModel()
                {
                    UserID = item.UserId,
                    OrderID = item.OrderId,
                    OrderDate = item.OrderDate,
                    Subtotal = item.TotalCost,
                    OrderedPizzas = _orderRepo.GetOrderedPizzasByOrderId(item.OrderId)
                };

                storeOrdersVM.Add(sOHVM);
            }

            return View(storeOrdersVM);
        }
    }
}