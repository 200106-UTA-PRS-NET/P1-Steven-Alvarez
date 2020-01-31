﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaBox.Web.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }

    }
}