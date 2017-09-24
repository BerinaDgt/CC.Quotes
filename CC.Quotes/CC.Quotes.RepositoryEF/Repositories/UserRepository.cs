using CC.Quotes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Quotes.Entities;

namespace CC.Quotes.RepositoryEF.Repositories
{
    public class UserRepository:IUserRepository
    {
        Database db = new Database();

        public bool Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var dbUser = GetById(id);

            if (dbUser != null)
            {
                db.Users.Remove(dbUser);
                db.SaveChanges();
                return true;
            }
            return true;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.UserID == id);
        }

        public bool Update(User user)
        {
            var dbUser = GetById(user.UserID);

            if (dbUser != null)
            {
                dbUser.Name = user.Name;
                dbUser.Email = user.Email;
                dbUser.ConfirmPassword = user.ConfirmPassword;
                dbUser.Password = user.Password;
                db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
