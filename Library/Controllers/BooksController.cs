using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private BookService bookService;

        public BooksController(BookService bookService)
        {
            this.bookService = bookService;
        }
        // GET: Books
        public ActionResult Index()
        {
            return View(bookService.Get());
        }

        // GET: Books/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, Book bookNew)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var book = bookService.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                bookService.Update(id, bookNew);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var book = bookService.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                bookService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}