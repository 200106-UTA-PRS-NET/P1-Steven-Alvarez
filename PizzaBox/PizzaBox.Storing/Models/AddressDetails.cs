using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Models
{
    public class AddressDetails
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string AddressState { get; set; }
        public int ZipCode { get; set; }
        public override string ToString()
        {
            return $"{this.Street}, {this.City}, {this.AddressState} {this.ZipCode}";
        }
    }
}
