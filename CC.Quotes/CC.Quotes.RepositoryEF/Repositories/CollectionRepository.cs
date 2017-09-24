using CC.Quotes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Quotes.Entities;

namespace CC.Quotes.RepositoryEF.Repositories
{
     public class CollectionRepository:ICollectionRepository
    {
        Database db = new Database();
        IUserRepository _userRepository = new UserRepository();
        IQuoteRepository _quoteRepository = new QuoteRepository();

        public List<Collection> GetAll()
        {
            return db.Collections.ToList();
        }

        public Collection GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.CollectionID == id);
        }

        public bool Create(Collection collection)
        {
            db.Collections.Add(collection);
            db.SaveChanges();
            return true;
        }

        public bool Update(Collection collection)
        {
            var dbCollection = GetById(collection.CollectionID);

            if (dbCollection != null)
            {
                dbCollection.Name = collection.Name;
                
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var dbCollection = GetById(id);

            if (dbCollection != null)
            {
                db.Collections.Remove(dbCollection);
                db.SaveChanges();
                return true;
            }
            return true;
        }
    }
}
