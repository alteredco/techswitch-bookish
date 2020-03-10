namespace Bookish.Models.Database
{
    public class Address
    {
        public int Id { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }
    }
}