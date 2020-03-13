using System;
using System.Collections.Generic;
using Bookish.Models.Database;
using Bookish.Models.Response;
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
        
        //GET:/Library
        [HttpGet("")]
        public IActionResult LibraryPage()
        {
            IEnumerable<Book> bookData = _bookService.GetAll();
            BookViewModel library = new BookViewModel(bookData);

            return View(library);
        }
        
        
        //POST: /Library/Create
        [HttpGet("/create")]
        public IActionResult AddBookPage()
        {
            return View();
        }
        
        [HttpPost("/create")]
        public IActionResult AddBookPage([FromForm]Book book)
        {
            if (!ModelState.IsValid)
            {
                return View("AddBookPage");
            } 
            _bookService.AddBook(book);
            return Redirect(Url.Action("LibraryPage"));
        }
            
    }
}