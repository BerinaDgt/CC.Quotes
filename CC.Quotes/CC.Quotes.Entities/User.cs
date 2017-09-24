using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Quotes.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Quote>FavoriteQuote { get; set; }
        public virtual ICollection <Collection> Collections { get; set; }
    }
}
