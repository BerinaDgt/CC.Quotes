using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Entities
{
    public class Quote
    {
        public int QuoteID { get; set; }
        public string Text { get; set; }
        public virtual int AuthorID { get; set; }
        public virtual Author Author { get; set; }


        public virtual ICollection<QuoteToCollections> Collections { get; set; }
        public QuoteCategory Category { get; set; }
    }
    public enum QuoteCategory
    {
        Inspirational = 0,
        Motivational = 1,
        Life = 2,
        Love =3,
        Funny =4,
        Positive=5,
        Friendship=6,
        Success=7,
        Happiness=8
    }


}
