using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        // ID книги
        public int Id { get; set; }
        // название книги
        public string Name { get; set; }
        // автор книги
        public string Author { get; set; }
        // автор книги
        public string Genre { get; set; }
        // количество лайков
        public int Like { get; set; }
        // колчество дизлайков
        public int Dislike { get; set; }

        public virtual ICollection<BookReview> BookReviews { get; set; }
    }
}