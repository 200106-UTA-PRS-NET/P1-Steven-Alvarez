using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Interfaces;
using System.Linq;
using PizzaBox.Domain.Entities;

namespace PizzaBox.Storing.Repositories
{
    public class UserRepos : IUser
    {
        readonly PizzaBoxDbContext db;

        static Users currentUser;


        public UserRepos()
        {
            db = new PizzaBoxDbContext();
        }

        public UserRepos(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }


        public void AddUser(Users user)
        {
            if (db.User.Any(c => c.Username == user.Username) || user.Username == null)
            {
                Console.WriteLine($"Sorry! The username, {user.Username} , already exists");

                return;
            }
            else
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }



        public bool Login(Users user)
        {
            try
            {
                var query = db.User.Where(u => u.Username == user.Username && u.Password == user.Password).Single();
                currentUser = query;

                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public void Logout()
        {
            currentUser = null;
        }
    
        public Users GetCurrUser()
        {
            return currentUser;
        }

        public void SetCurrUser(Users c)
        {
            currentUser = c;
        }

        public Users GetUserByID(int id)
        {
            var query = db.User.Where(c => c.Id == id).Single();
            return query;

        }

        public IEnumerable<Users> GetUsers()
        {
            var query = db.User.Select(c => c);
            return query;
        }

    }
}