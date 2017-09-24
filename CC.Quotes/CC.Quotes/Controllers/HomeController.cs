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
    public class HomeController : Controller
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
            


            ViewBag.AuthorsHome = _authorRepository.GetAll().OrderByDescending(a => a.AuthorID).Take(8);

            return View(quotes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TopicList(int id)
        {   
            return View();
        }
    }
}