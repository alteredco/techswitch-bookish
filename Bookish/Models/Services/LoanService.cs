using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models.Database;

namespace Bookish.Models.Services
{
    using Dapper;

    public interface ILoanService
    {
        IEnumerable<Loan> GetAll();
    }

    public class LoanService
    {
        private string connectionString = "Server=localhost; Database=bookish; Uid=wendy; Pwd=; Trusted_Connection=True;";

        public IEnumerable<Loan> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM loan JOIN member m on loan.member_id = m.id JOIN book b on loan.book_id = b.id";
                List<Loan> loans = connection.Query<Loan>(query).ToList();
                return loans;
            }
        }
    }
}