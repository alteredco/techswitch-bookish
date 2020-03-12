using System.Collections.Generic;
using Bookish.Models.Database;
using Bookish.Models.Services;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [Route("/loans")]
    public class LoanController : Controller
    {
        private readonly LoanService _loanService;

        public LoanController()
        {
            _loanService = new LoanService();
        }

        [HttpGet("")]
        public IActionResult LibraryLoansPage()
        {
            IEnumerable<Loan> loanData = _loanService.GetAll();
            LoanViewModel loans = new LoanViewModel(loanData);

            return View(loans);
        }
    }
}