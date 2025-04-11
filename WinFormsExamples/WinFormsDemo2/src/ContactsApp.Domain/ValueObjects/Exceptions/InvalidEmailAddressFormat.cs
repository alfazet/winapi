using System;

namespace ContactsApp.Domain.ValueObjects.Exceptions
{
    public class InvalidEmailAddressFormat:Exception
    {
        public string Email { get; }

        public InvalidEmailAddressFormat(string email)
        :base(string.Format(DomainResurces.InvalidEmailAddressFormatMessage,email))
        {
            Email = email;
        }
    }
}
