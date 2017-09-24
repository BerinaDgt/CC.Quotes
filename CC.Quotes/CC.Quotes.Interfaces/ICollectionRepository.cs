using CC.Quotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Interfaces
{
    public interface ICollectionRepository
    {
        List<Collection> GetAll();
        Collection GetById(int id);
        bool Create(Collection collection);
        bool Update(Collection collection);
        bool Delete(int id);
    }
}
