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
    public class UserController : Controller
    {
        private readonly IUser _repo;

        private readonly IOrder _orderRepo;

        private readonly IStore _storeRepo;

        private readonly IPizza _pizzaRepo;

        Users currUser;


        public UserController(IUser repo, IOrder orderRepo, IStore storeRepo, IPizza pizzaRepo)

        {

            _repo = repo;

            _orderRepo = orderRepo;

            _storeRepo = storeRepo;

            _pizzaRepo = pizzaRepo;

            currUser = _repo.GetCurrUser();

        }


        [Route("User")]
        [Route("User/Info")]
        public IActionResult Info(int? id)
        {

            if (currUser == null)
            {
                return RedirectToAction(nameof(Login));
            }
 

            UserViewModel uvm = new UserViewModel()
            {
                Name = currUser.Name,
                Username = currUser.Username
            };
            return View(uvm);
        }

        public IActionResult Logout()
        {
            _repo.Logout();
            return Redirect(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel user)
        {
            if (currUser != null)
            {
                return RedirectToAction("Info", currUser.Id);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    Users emp = new Users()
                    {
                        Username = user.Username,
                        Password = user.Password
                    };
                    if (_repo.Login(emp))

                    {

                        // login success

                        return RedirectToAction(nameof(Info), 1);

                    }


                    return Login();
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public IActionResult Register(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Users emp = new Users()
                    {
                        Name = user.Name,

                        Username = user.Username,
                        Password = user.Password
                    };
                    _repo.AddUser(emp);

                    return RedirectToAction("Login");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult OrderHistory()

        {

            if (currUser == null)

            {

                return RedirectToAction(nameof(Login));

            }



            var orders = _orderRepo.GetUserOrderHistoryById(currUser.Id);



            List<UserOHistoryViewModel> orderHistoryList = new List<UserOHistoryViewModel>();

            foreach (Order o in orders)

            {

                var pizzas = _orderRepo.GetOrderedPizzasByOrderId(o.OrderId).ToList();



                List<Pizza> pizzaa = new List<Pizza>();

                foreach (var p in pizzas)
                {

                    Pizza newp = new Pizza();

                    newp = _pizzaRepo.MapPizzaByIDs(p.CrustId.Value, p.SauceId.Value, p.CheeseId.Value, p.SizeId.Value, p.ToppingId.Value);

                    newp.Name = p.Name;

                    pizzaa.Add(newp);

                }



                UserOHistoryViewModel uohVM = new UserOHistoryViewModel()

                {

                    OrderId = o.OrderId,

                    OrderDate = o.OrderDate.Value,

                    StoreName = _storeRepo.GetStoreById(o.StoreId.Value).StoreName,

                    Subtotal = o.TotalCost.Value,

                    Pizzas = pizzaa

                };

                orderHistoryList.Add(uohVM);

            }



            return View(orderHistoryList);



        }



    }

}
   
