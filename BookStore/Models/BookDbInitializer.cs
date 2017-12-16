using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            for (int i = 1; i < 100; i++)
            {
                string bookName = "BookName_" + i;
                string bookAuthorName = "BookAuthorName_" + i;
                string bookGenre = "BookGenre_" + i;
                db.Books.Add(new Book { Name = bookName, Author = bookAuthorName, Genre = bookGenre });
                for (int j = 1; j < 10; j++)
                {
                    string reviewerName = "ReviewerName_" + j;
                    string reviewText = "ReviewText_" + j;
                    db.Review.Add(new BookReview
                    {
                        Name = reviewerName,
                        Review = reviewText,
                        BookName = bookName,
                        Id = j,
                        BookId = i
                    });
                }
            }
           
            base.Seed(db);
        }
    }
}