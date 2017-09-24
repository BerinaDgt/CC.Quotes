using CC.Quotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Interfaces
{
     public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(int id);
        bool Create(Author author);
        bool Update(Author author);
        bool Delete(int id);
    }
}
