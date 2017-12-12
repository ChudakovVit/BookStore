using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookReview
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String BookName { get; set; }

        public String Review { get; set; }

        public int BookId { get; set; }
    }
}