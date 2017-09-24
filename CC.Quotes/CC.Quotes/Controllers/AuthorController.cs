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
    public class AuthorController : Controller
    {
        IAuthorRepository _authorRepository = new AuthorRepository();

        Database db = new Database();
        // GET: Author
        public ActionResult Index(int? page)
        {
            var authors = _authorRepository.GetAll();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                if (_authorRepository.Create(author))
                    return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(Author author)
        {
            return View(_authorRepository.GetById(author.AuthorID));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_authorRepository.Delete(id))
                return RedirectToAction("Index");

            return View();
        }
        public ActionResult Edit(int id)
        {
            return View(_authorRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                if (_authorRepository.Update(author))
                    return RedirectToAction("Index");
            }

            return View(author);
        }

    }
}