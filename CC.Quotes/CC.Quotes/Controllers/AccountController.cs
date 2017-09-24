using CC.Quotes.Entities;
using CC.Quotes.Interfaces;
using CC.Quotes.RepositoryEF;
using CC.Quotes.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CC.Quotes.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository _userRepository = new UserRepository();
        Database db = new Database();

        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {
            var dbUser = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (dbUser != null)
            {
                FormsAuthentication.SetAuthCookie(email, true);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password, please try again";

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Create(user))
                    return RedirectToAction("LogIn");
            }

            return View();
        }
    }
}