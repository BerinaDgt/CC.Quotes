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
    public class QuoteController : Controller
    {
        IAuthorRepository _authorRepository = new AuthorRepository();
        IQuoteRepository _quoteRepository = new QuoteRepository();

        Database db = new Database();
        // GET: Quote
        public ActionResult Index(int? page)
        {
            var quotes = _quoteRepository.GetAll();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(quotes.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            ViewBag.Authors = _authorRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                if (_quoteRepository.Create(quote))
                    return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(Quote quote)
        {
            return View(_quoteRepository.GetById(quote.QuoteID));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_quoteRepository.Delete(id))
                return RedirectToAction("Index");

            return View();
        }
        public ActionResult Edit(int id)
        {
            return View(_quoteRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Quote quote)
        {
            if (ModelState.IsValid)
            {
                if (_quoteRepository.Update(quote))
                    return RedirectToAction("Index");
            }

            return View(quote);
        }
    }
}