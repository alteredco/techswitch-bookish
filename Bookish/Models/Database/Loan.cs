using System;

namespace Bookish.Models.Database
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateIn { get; set; }
        public string Status { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
}