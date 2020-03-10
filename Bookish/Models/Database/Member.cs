namespace Bookish.Models.Database
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
    }
}