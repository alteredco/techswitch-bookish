using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models.Database;

namespace Bookish.Models.Services
{
    using Dapper;

    public interface IMemberService
    {
        IEnumerable<Member> GetAll();
    }

    public class MemberService
    {
        private string connectionString = "Server=localhost; Database=bookish; Uid=wendy; Pwd=; Trusted_Connection=True;";

        public IEnumerable<Member> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM member JOIN address a on member.address_id = a.id";
                List<Member> members = connection.Query<Member>(query).ToList();
                return members;
            }
        }
        
    }
}