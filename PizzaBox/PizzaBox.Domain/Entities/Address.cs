using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class Address
    {
        public Address()
        {
            Store = new HashSet<Store>();

            Users = new HashSet<Users>();
        }
        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string AddressState { get; set; }
        public int ZipCode { get; set; }
    }

}