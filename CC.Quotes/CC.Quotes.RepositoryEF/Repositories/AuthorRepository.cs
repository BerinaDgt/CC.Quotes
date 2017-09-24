using CC.Quotes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Quotes.Entities;

namespace CC.Quotes.RepositoryEF.Repositories
{
   public class AuthorRepository:IAuthorRepository
    {
        Database db = new Database();

        public bool Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var dbAuthor = GetById(id);

            if (dbAuthor != null)
            {
                db.Authors.Remove(dbAuthor);
                db.SaveChanges();
                return true;
            }
            return true;
        }

        public List<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.AuthorID == id);
        }

        public bool Update(Author author)
        {
            var dbAuthor = GetById(author.AuthorID);

            if (dbAuthor != null)
            {
                dbAuthor.Name = author.Name;
                dbAuthor.Type = author.Type;
                dbAuthor.Nationality = author.Nationality;
                db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
