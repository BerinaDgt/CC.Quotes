using CC.Quotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Interfaces
{
    public interface IQuoteRepository
    {
        List<Quote> GetAll();
        Quote GetById(int id);
        Quote GetByCategory(int Category);
        bool Create(Quote quote);
        bool Update(Quote quote);
        bool Delete(int id);
    }
}
