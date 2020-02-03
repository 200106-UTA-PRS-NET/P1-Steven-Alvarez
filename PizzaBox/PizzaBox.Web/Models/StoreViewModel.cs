﻿using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaBox.Web.Models
{
    public class StoreViewModel
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public int Id { get; set; }
        public string WaitTime { get; set; }
    }
}