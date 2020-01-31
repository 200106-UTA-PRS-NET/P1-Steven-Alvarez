using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Web.Models
{
    public class CustomPizzaViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Required]
        public int SelectedCrustId { get; set; }

        [Required]
        public int SelectedSauceId { get; set; }

        [Required]
        public int SelectedCheeseId { get; set; }

        [Required]
        public int SelectedSizeId { get; set; }

        [Required]
        public int SelectedToppingId { get; set; }

    }
}