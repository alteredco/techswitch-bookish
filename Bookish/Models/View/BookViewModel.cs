using System.Collections.Generic;
using ASP;
using Bookish.Models.Database;

namespace Bookish.Models.View
{
    public class BookViewModel
    {
        public IEnumerable<Book> BookList { get; set; }
        public BookViewModel(IEnumerable<Book> bookList)
        {
            BookList = bookList;
        }
    }
}