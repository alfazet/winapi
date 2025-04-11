using System;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Aggregates.Exceptions
{
    public class EmailAlreadyAddedAsPrimary : Exception
    {
        public EmailAddress Email { get; }

        public EmailAlreadyAddedAsPrimary(EmailAddress emailAddress)
            : base(string.Format(DomainResurces.PhoneAlreadyAddedAsPrimaryMessage, emailAddress?.Email))

        {
            Email = emailAddress;
        }
    }
}