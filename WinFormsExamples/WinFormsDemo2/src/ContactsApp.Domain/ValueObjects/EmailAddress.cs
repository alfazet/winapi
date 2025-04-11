using System;
using System.Collections.Generic;
using System.Net.Mail;
using ContactsApp.Domain.ValueObjects.Exceptions;

namespace ContactsApp.Domain.ValueObjects
{
    public class EmailAddress : ValueObject<EmailAddress>
    {
        public string Email { get; }
        public EmailAddress(string emailAddress)
        {
            Email = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            if (!ValidateEmail(Email)) throw new InvalidEmailAddressFormat(Email);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }

        public override string ToString()
        {
            return Email;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var adr = new MailAddress(email).Address;
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }
    }
}
