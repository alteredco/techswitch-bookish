using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Bookish.Models.Database;
using MySql.Data.MySqlClient;

namespace Bookish.Models.Services
{
    using Dapper;

    public interface IMemberService
    {
        IEnumerable<Member> GetAll();
    }

    public class MemberService
    {
        private string connectionString = "Server=localhost; Database=bookish; Uid=root; Pwd=;";

        public IEnumerable<Member> GetAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT * FROM member JOIN address a on member.address_id = a.id";
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                List<Member> members = connection.Query<Member>(query).ToList();
                return members;
            }
        }
        
    }
}