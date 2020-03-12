using System;
using System.Collections.Generic;
using Bookish.Models.Database;
using Bookish.Models.Services;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [Route("/library")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        
        [HttpGet("")]
        public IActionResult LibraryPage()
        {
            IEnumerable<Book> bookData = _bookService.GetAll();
            BookViewModel library = new BookViewModel(bookData);

            return View(library);
        }

        /*public BookController()
        {
            _service = new BookService();
        }
    
        public BookController(IBookService service)
        {
            _service = service;
        }*/

        /*public ActionResult Index()
        {
            return View(_service.GetAll());
        }
        
        //GET: /Book/Create
        public IActionResult GetAll()
        {
            return View(_service.GetAll());
        }
        
        //POST: /Book/Create
        public IActionResult CreateBook()
        {
            if (!_service.CreateBook())
            {
                /*return View();#1#
            }
            return RedirectToAction("Index");
        }*/
    }
}