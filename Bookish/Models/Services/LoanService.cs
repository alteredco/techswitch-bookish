using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models.Database;
using MySql.Data.MySqlClient;

namespace Bookish.Models.Services
{
    using Dapper;

    public interface ILoanService
    {
        IEnumerable<Loan> GetAll();
    }

    public class LoanService
    {
        private string connectionString = "Server=localhost; Database=bookish; Uid=root; Pwd=;";

        public IEnumerable<Loan> GetAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT * FROM loan JOIN member m on loan.member_id = m.id JOIN book b on loan.book_id = b.id";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<Loan> loans = connection.Query<Loan>(query).ToList();
                return loans;
            }
        }
    }
}