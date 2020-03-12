using Bookish.Models.Database;
using Bookish.Models.Services;

namespace Bookish.Models.Response
{
    public class CreateBookModel
    {
        private Book _book;

        public CreateBookModel(Book book)
        {
            _book = book;
        }
            
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }
        public string Isbn { get; set; }
    }
}