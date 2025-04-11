using System;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Aggregates.Exceptions
{
    public class PhoneAlreadyAddedAsPrimary:Exception
    {
        public PhoneNumber PhoneNumber { get; }

        public PhoneAlreadyAddedAsPrimary(PhoneNumber phoneNumber)
            :base(string.Format(DomainResurces.PhoneAlreadyAddedAsPrimaryMessage,phoneNumber?.FullNumber))

        {
            PhoneNumber = phoneNumber;
        }
    }
}
