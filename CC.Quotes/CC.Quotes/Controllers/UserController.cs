using CC.Quotes.Entities;
using CC.Quotes.Interfaces;
using CC.Quotes.RepositoryEF;
using CC.Quotes.RepositoryEF.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.Quotes.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _userRepository = new UserRepository();

        Database db = new Database();
        // GET: User
        public ActionResult Index(int? page)
        {
            var users = _userRepository.GetAll();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Create(user))
                    return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Delete(User user)
        {
            return View(_userRepository.GetById(user.UserID));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_userRepository.Delete(id))
                return RedirectToAction("Index");

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_userRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Update(user))
                    return RedirectToAction("Index");
            }

            return View(user);
        }

        public JsonResult AddFavourite(int quoteId, string user)
        {
            
            var dbUser = db.Users.Single(u => u.Email == User.Identity.Name);

            if(dbUser != null)
            {
                   
            }

            return Json(false);
        }
    }
}