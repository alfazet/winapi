using ContactsApp.Domain.ValueObjects;

namespace Lecture2.Models
{
    public class AddressModel
    {
        public AddressModel(Address address)
        {
            City = address.City;
            Street = address.Street;
            HouseNumber = address.HouseNumber;
            FlatNumber = address.FlatNumber;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }

        public Address Build()
        {
            return new Address(City,Street,HouseNumber,FlatNumber);
        }

    }
}