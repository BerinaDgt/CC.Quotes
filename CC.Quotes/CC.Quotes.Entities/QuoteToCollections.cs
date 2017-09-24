using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Entities
{
    public class QuoteToCollections
    {
        public int ID { get; set; }
        public int QuoteID { get; set; }
        public int CollectionID { get; set; }

        public virtual Quote Quote { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
