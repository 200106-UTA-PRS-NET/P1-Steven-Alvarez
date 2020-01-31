using PizzaBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IUser
    {
        public IEnumerable<Users> GetUsers();

        public Users GetUserByID(int id);

        public void AddUser(Users user);



        public Users GetCurrUser();

        public void SetCurrUser(Users u);

        public bool Login(Users u);

        public void Logout();
    }
}
