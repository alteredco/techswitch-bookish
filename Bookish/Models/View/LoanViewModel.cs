using System.Collections.Generic;
using Bookish.Models.Database;

namespace Bookish.Models.View
{
    public class LoanViewModel
    {
        public IEnumerable<Loan> LoanList { get; set; }

        public LoanViewModel(IEnumerable<Loan> loanList)
        {
            LoanList = loanList;
        }
    }
}