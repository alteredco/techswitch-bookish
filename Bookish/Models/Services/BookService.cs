using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
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
        void AddBook(Book newBook);
        Book GetById(int id);
        Book GetTitle(string title);
        Book GetByAuthorLastName(string authorName);
        Book GetGenre(string genre);
        Book GetIsbn(string isbn);
        Book GetQuantity(int quantity);
        void DeleteById(int id);
        public void UpdateByid(int id);
    }

    public class BookService: IBookService
    {
         private string connectionString = "Server=localhost; Database=bookish; Uid=root; Pwd=;";
        // private readonly ConnectionString _connectionString;
        public IDbConnection Connection
        {
            get
            {
                return  new MySqlConnection(connectionString);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<Book> books = connection.Query<Book>(query).ToList();
                return books;
            }
        }

        public void AddBook(Book newBook)
        {
            using (var connection = Connection)
            {
                string query = @"INSERT INTO book (title, author_first_name, author_last_name, genre, quantity, isbn) VALUES(@title, @authorFirstName, @authorLastName, @genre,1, @isbn)";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                connection.Execute(query,new {title = newBook.Title, authorFirstName = newBook.AuthorFirstName, authorLastName = newBook.AuthorLastName, genre = newBook.Genre, quantity = newBook.Quantity, isbn = newBook.Isbn });
            }
        }
            
        public Book GetById(int id)
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book WHERE book.id = @id";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                Book book = connection.Query<Book>(query, new {Id = id}).FirstOrDefault();
                return book;
            }
        }

        public Book GetTitle(string title)
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book WHERE book.title = @title";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                Book book = connection.Query<Book>(query, new {Title = title}).FirstOrDefault();
                return book;
            }
        }

        public Book GetByAuthorLastName(string authorName)
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book WHERE book.author_last_name = @authorName";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                Book book = connection.Query<Book>(query, new {AuthorLastName = authorName}).FirstOrDefault();
                return book;
            }
        }
    
        public Book GetGenre(string genre)
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book WHERE book.genre = @genre";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                Book book = connection.Query<Book>(query, new {Genre = genre}).FirstOrDefault();
                return book;
            }
        }
    
        public Book GetIsbn(string isbn)
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book WHERE book.isbn = @isbn";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                Book book = connection.Query<Book>(query, new {Isbn = isbn}).FirstOrDefault();
                return book;
            }
        }
    
        public Book GetQuantity(int quantity)
        {
            using (var connection = Connection)
            {
                string query = @"SELECT * FROM book WHERE book.quantity = @quantity";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                Book book = connection.Query<Book>(query, new {Quantity = quantity}).FirstOrDefault();
                return book;
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = Connection)
            {
                string query = @"DELETE FROM book WHERE book.id = @id";
                connection.Open();
                connection.Execute(query, new {Id = id});
            }
        }
        
        public void UpdateByid(int id)
        {
            using (var connection = Connection)
            {
                string query = @"UPDATE book SET title=@title, author_first_name=@authorFirstName, author_last_name=@authorLastName, genre, quantity, isbn";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                connection.Open();
                connection.Execute(query, new {Id = id});
            }
        }
        
    }
}