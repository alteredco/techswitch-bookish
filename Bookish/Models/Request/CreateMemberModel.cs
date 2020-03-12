using Bookish.Models.Database;

namespace Bookish.Models.Response
{
    public class CreateMemberModel
    {
        private Member _member;

        public CreateMemberModel(Member member)
        {
            _member = member;
        }
        
        public int Id { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
    }
}