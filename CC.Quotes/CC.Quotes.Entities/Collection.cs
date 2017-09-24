using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Entities
{
   public class Collection
    {
        public int CollectionID { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<QuoteToCollections> Quote { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
