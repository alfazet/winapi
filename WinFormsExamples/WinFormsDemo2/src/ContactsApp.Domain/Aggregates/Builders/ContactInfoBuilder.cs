using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Domain.Aggregates.Exceptions;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain
{
    public partial class ContactInfo
    {
        public class Builder
        {
            private ContactInfo _entity;


            public Builder(Guid id, string name, PhoneNumber primatyPhoneNumber)
            {
                _entity = new ContactInfo(id, name, primatyPhoneNumber);
            }
            public Builder(Guid id, string name, string phoneNumber)
                : this(id, name, new PhoneNumber(phoneNumber))
            {
            }

            public Builder(string name, PhoneNumber primatyPhoneNumber)
            {
                _entity = new ContactInfo(name, primatyPhoneNumber);
            }
            public Builder(string name, string primatyPhoneNumber)
                : this(name, new PhoneNumber(primatyPhoneNumber))
            {
            }


            public Builder WithAdress(Address address)
            {
                _entity.Adress = address;
                return this;
            }
            public Builder WithAlternateEmails(IEnumerable<EmailAddress> emailAddresses)
            {
                _entity._alternateEmailAddresses.AddRange( emailAddresses.ToList());
                return this;
            }
            public Builder WithPrimaryEmail(EmailAddress emailAddress)
            {
                _entity.PrimaryEmail = emailAddress;
                return this;
            }
            public Builder WithAlternatePhoneNumbers(IEnumerable<PhoneNumber> phoneNumbers)
            {
                _entity._alternatePhoneNumbers.AddRange(phoneNumbers);
                return this;
            }
            public Builder WithPersonalData(ContactPersonalData contactPersonalData)
            {
                _entity.PersonalData = contactPersonalData;
                return this;
            }
            public Builder WithPhoto(ContactPhoto photo)
            {
                _entity.Photo = photo;
                return this;
            }


            public ContactInfo Build()
            {
                if (_entity == null)
                    throw new BuilderAlreadyCreateObject();
                try
                {
                    return _entity;
                }
                finally
                {
                    _entity = null;
                }
            }

        }
    }
}
