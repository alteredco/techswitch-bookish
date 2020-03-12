using System.Collections.Generic;
using Bookish.Models.Database;

namespace Bookish.Models.View
{
    public class MemberViewModel
    {
        public IEnumerable<Member> MemberList { get; set; }

        public MemberViewModel(IEnumerable<Member> memberList)
        {
            MemberList = memberList;
        }
    }
}