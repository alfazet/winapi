using System;

namespace ContactsApp.Domain.ValueObjects.Exceptions
{
    public class InvalidPhoneNumberFormat:Exception
    {
        public string Number { get; }

        public InvalidPhoneNumberFormat(string number)
            :base(string.Format(DomainResurces.InvalidPhoneNumberFormatMessage,number))
        {
            Number = number;
        }
    }
}
