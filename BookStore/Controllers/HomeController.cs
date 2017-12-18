using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index(int? page)
        {
            int sizePage = 20;
            int pageIndex = (page ?? 1);
            if ( pageIndex < 1 )
            {
                pageIndex = 1;
            }
            // возвращаем представление
            return View(db.Books.ToList().ToPagedList(pageIndex, sizePage));
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

        public ActionResult Edit(int? id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Author, Genre")] Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Like()
        {
            int bookId = int.Parse(Request.Form.Get("bookId"));
            Book book = db.Books.Find(bookId);
            book.Like++;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Dislike()
        {
            int bookId = int.Parse(Request.Form.Get("bookId"));
            Book book = db.Books.Find(bookId);
            book.Dislike++;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}