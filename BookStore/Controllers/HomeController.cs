using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Author, Genre")] Book book)
        {
            if (ModelState.IsValid)
            {
                // Добавим книгу в базу
                db.Books.Add(book);
                // Сохраним изменения
                db.SaveChanges();
                //Перейдем на начальную страницу 
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }
    }
}