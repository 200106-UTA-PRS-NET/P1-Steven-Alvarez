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
        public UserController(IUser repo)
        {
            _repo = repo;
        }
        [Route("User")]
        [Route("User/Info")]
        public IActionResult Info(int? id)
        {
            var currUser = _repo.GetCurrUser();
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
            var currUser = _repo.GetCurrUser();
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
    }
}