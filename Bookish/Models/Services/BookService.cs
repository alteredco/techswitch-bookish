using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bookish.Controllers;
using Bookish.Models.Database;
using Bookish.Models.Response;
using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Bookish.Models.Services
{
    using Dapper;
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        // BookService GetById(int id);
        // void Add(BookService newBook);
        // string GetTitle(int id);
        // string GetAuthor(int id);
        // string GetGenre(int id);
        // string GetIsbn(int id);
        // string GetQuantity(int id);
    }

    public class BookService: IBookService
    {
         private string connectionString = "Server=localhost; Database=bookish; Uid=root; Pwd=;";
        // private readonly ConnectionString _connectionString;

        public IEnumerable<Book> GetAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT * FROM book";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<Book> books = connection.Query<Book>(query).ToList();
                return books;
            }
            /*public void Add(BookService newBook)
            {
                try
                {
                    _dbBook.Add(newBook);
                    _dbBook.SaveChanges();
                }
                catch
                {
                    throw new System.NotImplementedException();
                }
               
            }
            
            public BookService GetById(int id)
            {
                return
                    GetAll()
                        .FirstOrDefault(book => book.id == id);
            }
    
            public string GetTitle(int id)
            {
                if (_dbBook.Any(book => book.id == id))
                {
                    return _dbBook.Title;
                }
                else
                {
                    return " ";
                }
            }
    
            public string GetAuthor(int id)
            {
                if (_dbBook.Any(book => book.id == id))
                {
                    return _dbBook.AuthorFirstName + " "+_dbBook.AuthorLastName;
                }
                else
                {
                    return " ";
                }
            }
    
            public string GetGenre(int id)
            {
                if (_dbBook.Any(book => book.id == id))
                {
                    return _dbBook.Genre;
                }
                else
                {
                    return " ";
                }
            }
    
            public string GetIsbn(int id)
            {
                if (_dbBook.Any(book => book.id == id))
                {
                    return _dbBook.Isbn;
                }
                else
                {
                    return " ";
                }
            }
    
            public string GetQuantity(int id)
            {
                if (_dbBook.Any(book => book.id == id))
                {
                    return _dbBook.Quantity.ToString();
                }
                else
                {
                    return " ";
                }
            }*/
        }
    }
}