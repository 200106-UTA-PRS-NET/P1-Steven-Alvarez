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
        private readonly IOrder _oR;



        public StoreController(IUser userRepo, IStore storeRepo, IPizza pizzaRepo, IOrder orderRepo)

        {
            _uR = userRepo;
            _sR = storeRepo;
            _pR = pizzaRepo;
            _oR = orderRepo;
            currUser = _uR.GetCurrUser();
        }

        public IActionResult Index()
        {
            if (currUser == null)
            {
                return RedirectToAction("Login", "User");
            }

            _oR.ClearOrder();
            var stores = _sR.GetStores();

            List<StoreViewModel> storeVM = new List<StoreViewModel>();

            foreach (var item in stores)

            {

                if (_sR.GetLastOrderDate(item.StoreId, currUser.Id).HasValue)

                {

                    // customer has previous order from this restaurant

                    DateTime lastOrder = _sR.GetLastOrderDate(item.StoreId, currUser.Id).Value;

                    TimeSpan timeSinceLastOrder = DateTime.Now - lastOrder;

                    TimeSpan waitTime = DateTime.Now - lastOrder.AddHours(1);



                    if (timeSinceLastOrder.TotalHours > 1)

                    {

                        // time since last order more than an hour from now - > can order

                        StoreViewModel store = new StoreViewModel()

                        {

                            Name = item.StoreName,

                            Id = item.StoreId,

                            WaitTime = TimeSpan.Zero.ToString()

                        };

                        storeVM.Add(store);



                    }

                    else

                    {

                        // last order was within an hour before

                        StoreViewModel store = new StoreViewModel()

                        {

                            Name = item.StoreName,

                            Id = item.StoreId,

                            WaitTime = waitTime.ToString(@"hh\:mm")

                        };

                        storeVM.Add(store);



                    }

                }

                else

                {

                    // customer no previous order

                    StoreViewModel store = new StoreViewModel()

                    {

                        Name = item.StoreName,

                        Id = item.StoreId,

                        WaitTime = TimeSpan.Zero.ToString()



                    };

                    storeVM.Add(store);

                }





            }
            return View(storeVM);
        }
       
        public IActionResult CustomPizza()
        {
            if (currUser == null)
            {
                return RedirectToAction("Login", "User");
            }

            Dictionary<Toppings, bool> top = new Dictionary<Toppings, bool>();

            foreach (var topping in _pR.GetToppingTypes())
            {
                top.Add(topping, false);
            }

 

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
        public IActionResult Preset(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }

            if (currUser == null)

            {

                return RedirectToAction("Login", "User");

            }



            Pizza p = _pR.GetPizzaById(id.Value);



            CustomPizzaViewModel cpVM = new CustomPizzaViewModel()

            {

                Name = p.Name,

                SelectedCrustId = p.CrustId.Value,

                SelectedCheeseId = p.CheeseId.Value,

                SelectedSauceId = p.SauceId.Value,

                SelectedSizeId = p.SizeId.Value,

                SelectedToppingId = p.ToppingId.Value,


            };



            return RedirectToAction("Confirmation", cpVM);

        }

        [HttpGet]
        public IActionResult Confirmation(CustomPizzaViewModel C)
        {
            if (currUser == null)

            {

                return RedirectToAction("Login", "User");

            }
            Pizza p = _pR.MapPizzaByIDs(C.SelectedCrustId, C.SelectedSauceId, C.SelectedCheeseId, C.SelectedSizeId, C.SelectedToppingId);
            _oR.SetCurrentPizza(p);
            string pizzaName;



            if (C.Name == "" || C.Name == null)

            {

                pizzaName = "CustomPizza";

            }
            else

            {

                pizzaName = C.Name;

            }
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
        public IActionResult Confirmation(PizzaViewModel pizzaVM)
        {

            if (currUser == null)

            {

                return RedirectToAction("Login", "User");

            }



            Pizza p = _oR.GetCurrentPizza();
            _oR.AddPizzaToOrder(p, _pR.GetPriceByPizza(p));

            return RedirectToAction("OrderView", "OrderController");
        }

        // Displays store order history
        public IActionResult OrderHistory(int? id)
        {

            if (currUser == null)

            {

                return RedirectToAction("Login", "User");

            }
            List<Order> orders = _oR.GetStoreOrderHistoryById(id.Value);

            List<StoreOHistoryViewModel> storeOrdersVM = new List<StoreOHistoryViewModel>();

            foreach (var item in orders)
            {

                var pizzas = _oR.GetOrderedPizzasByOrderId(item.OrderId).ToList();



                List<Pizza> pizzaa = new List<Pizza>();

                foreach (var p in pizzas)

                {

                    Pizza newp = new Pizza();

                    newp = _pR.MapPizzaByIDs(p.CrustId.Value, p.SauceId.Value, p.CheeseId.Value, p.SizeId.Value, p.ToppingId.Value);

                    newp.Name = p.Name;

                    pizzaa.Add(newp);

                }


                StoreOHistoryViewModel sOHVM = new StoreOHistoryViewModel()
                {
                    UserID = item.UserId.Value,
                    OrderID = item.OrderId,
                    OrderDate = item.OrderDate.Value,
                    Subtotal = item.TotalCost.Value,
                    OrderedPizzas = pizzaa
                };

                storeOrdersVM.Add(sOHVM);
            }

            return View(storeOrdersVM);
        }
       
        public IActionResult Menu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_sR.GetLastOrderDate(id.Value, currUser.Id).HasValue)

            {

                // customer has previous order from this restaurant

                DateTime lastOrder = _sR.GetLastOrderDate(id.Value, currUser.Id).Value;

                TimeSpan timeSinceLastOrder = DateTime.Now - lastOrder;

                TimeSpan waitTime = DateTime.Now - lastOrder.AddHours(1);



                if (timeSinceLastOrder.TotalHours > 1)

                {

                    // time since last order more than an hour from now - > can order





                }

                else

                {

                    // last order was within an hour before -> can't order

                    return RedirectToAction("Index");



                }

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

    }
}