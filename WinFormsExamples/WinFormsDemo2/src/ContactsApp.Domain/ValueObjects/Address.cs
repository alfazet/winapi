using System.Collections.Generic;

namespace ContactsApp.Domain.ValueObjects
{
    public class Address:ValueObject<Address>
    {
        public string City { get; }
        public string Street { get; }
        public string HouseNumber { get; }
        public string FlatNumber { get; }

        public Address(string city, string houseNumber)
            :this(city,null,houseNumber,null)
        {

        }

        public Address(string city, string street, string houseNumber, string flatNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return HouseNumber;
            yield return FlatNumber;
        }

        public override string ToString()
        {
            return $"{City} {Street} {HouseNumber} {FlatNumber}";
        }
    }
}
