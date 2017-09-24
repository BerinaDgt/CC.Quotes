using CC.Quotes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Quotes.Entities;

namespace CC.Quotes.RepositoryEF.Repositories
{
   public class QuoteRepository:IQuoteRepository
    {
        Database db = new Database();
        IAuthorRepository _authorRepository = new AuthorRepository();

        public bool Create(Quote quote)
        {
            db.Quotes.Add(quote);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var dbQuotes = GetById(id);

            if (dbQuotes != null)
            {
                db.Quotes.Remove(dbQuotes);
                db.SaveChanges();
                return true;
            }
            return true;
        }

        public List<Quote> GetAll()
        {
            return db.Quotes.ToList();
        }

        public Quote GetByCategory(int Category)
        {
            throw new NotImplementedException();
        }

        public Quote GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.QuoteID == id);
        }

        public bool Update(Quote quote)
        {
            var dbQuotes = GetById(quote.QuoteID);

            if (dbQuotes != null)
            {
                dbQuotes.Text = quote.Text;
                dbQuotes.Category = quote.Category;
              
                db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
