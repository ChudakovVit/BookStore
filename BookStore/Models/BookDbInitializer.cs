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
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Genre = "Комедия" });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Genre = "Сатира" });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Genre = "Юмор" });
            db.Review.Add(new BookReview { Name = "asdas", Review = "adasd", BookName = "asdfff", Id = 0, BookId = 1 });

            base.Seed(db);
        }
    }
}