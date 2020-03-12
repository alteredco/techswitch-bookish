using Bookish.Models.Database;

namespace Bookish.Models.Response
{
    public class CreateAddressModel
    {
        private Address _address;

        public CreateAddressModel(Address address)
        {
            _address = address;
        }
        
        public int Id { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }
    }
}