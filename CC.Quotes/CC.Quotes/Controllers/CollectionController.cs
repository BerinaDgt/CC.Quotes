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
    public class CollectionController : Controller
    {
        IUserRepository _userRepository = new UserRepository();
        IQuoteRepository _quoteRepository = new QuoteRepository();
        ICollectionRepository _collectionRepository = new CollectionRepository();

        Database db = new Database();
        // GET: Collection
       
        public ActionResult Index(int? page)
        {
            var collections = _collectionRepository.GetAll();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(collections.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            ViewBag.Quotes = _quoteRepository.GetAll();
            ViewBag.Users = _userRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            if (ModelState.IsValid)
            {
                if (_collectionRepository.Create(collection))
                    return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Delete(Collection collection)
        {
            return View(_collectionRepository.GetById(collection.CollectionID));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_collectionRepository.Delete(id))
                return RedirectToAction("Index");

            return View();
        }
        public ActionResult Edit(int id)
        {
            return View(_collectionRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Collection collection)
        {
            if (ModelState.IsValid)
            {
                if (_collectionRepository.Update(collection))
                    return RedirectToAction("Index");
            }

            return View(collection);
        }
    }
}