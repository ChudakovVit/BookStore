using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookReviewController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int bookId, string bookName)
        {
            BookReview br = new BookReview() { BookId = bookId, BookName = bookName };
            return View(br);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, BookName, Review, BookId")] BookReview bookReview)
        {
            if (ModelState.IsValid)
            {
                // Добавим ревью в базу
                db.Review.Add(bookReview);
                // Сохраним изменения
                db.SaveChanges();
                //Перейдем на начальную страницу 
                return RedirectToAction("Details", "Home", new { id = bookReview.BookId});
            }

            return View(bookReview);
        }
    }
}