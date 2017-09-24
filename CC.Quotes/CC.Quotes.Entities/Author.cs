using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string  Nationality { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }


        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
