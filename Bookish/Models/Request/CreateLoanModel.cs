using System;
using Bookish.Models.Database;

namespace Bookish.Models.Response
{
    public class CreateLoanModel
    {
        private Loan _loan;

        public CreateLoanModel(Loan loan)
        {
            _loan = loan;
        }
        
        public int Id { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateIn { get; set; }
        public string Status { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        
    }
}