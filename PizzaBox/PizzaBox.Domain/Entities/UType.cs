using System;
using System.Collections.Generic;


namespace PizzaBox.Domain.Entities
{
    public partial class UType
    {
        public UType()
        {
            User = new HashSet<Users>();
        }

        public int UTypeId { get; set; }
        public string UType1 { get; set; }

        public virtual ICollection<Users> User { get; set; }
    }
}