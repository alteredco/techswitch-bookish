using System.Collections.Generic;
using Bookish.Models.Database;
using Bookish.Models.Services;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [Route("/members")]
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;
        public MemberController()
        {
            _memberService = new MemberService();
        }
        
        [HttpGet("")]
        public IActionResult MembersPage()
        {
            IEnumerable<Member> memberData = _memberService.GetAll();
            var members = new MemberViewModel(memberData);

            return View(members);
        }
        
        //POST: /Member/Create
        [HttpGet("/membership")]
        public IActionResult AddMemberPage()
        {
            return View();
        }
        
        [HttpPost("/membership")]
        public IActionResult AddMemberPage([FromForm]Member member)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMemberPage");
            } 
            _memberService.AddMember(member);
            return Redirect(Url.Action("MembersPage"));
        }
    }
}