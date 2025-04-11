using System;
using System.Collections.Generic;
using ContactsApp.Domain.ValueObjects;
using System.Linq;
using ContactsApp.Domain.Aggregates.Exceptions;
using ContactsApp.Domain.Shared;

// ReSharper disable once CheckNamespace
namespace ContactsApp.Domain
{
    public partial class ContactInfo
    {
        private ContactInfo(string name, PhoneNumber phoneNumber)
            :this(Guid.NewGuid(), name,phoneNumber)
        {

        }
        private ContactInfo(Guid id, string name, PhoneNumber primaryPhoneNumber)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (primaryPhoneNumber == null) throw new ArgumentNullException(nameof(primaryPhoneNumber));
            if(Guid.Empty.Equals(id)) throw new ArgumentException($"{nameof(id)} cannot be empty");


            Id = id;
            Name = name;
            PrimaryPhoneNumber = primaryPhoneNumber;

        }

        private readonly List<PhoneNumber> _alternatePhoneNumbers = new List<PhoneNumber>(Consts.DefaultSizeOfAltenrativeCollection); 
        private readonly List<EmailAddress> _alternateEmailAddresses = new List<EmailAddress>(Consts.DefaultSizeOfAltenrativeCollection);

        public Guid Id { get;}
        public string Name { get; }

        public PhoneNumber PrimaryPhoneNumber { get; private set; }
        public IEnumerable<PhoneNumber> AlternatePhoneNumbers => _alternatePhoneNumbers.AsEnumerable();

        public EmailAddress PrimaryEmail { get; private set; }

        public IEnumerable<EmailAddress> AltenrnateEmails => _alternateEmailAddresses.AsEnumerable();
        public ContactPhoto Photo { get; private set; }
        public ContactPersonalData PersonalData { get; private set; }
        public Address Adress { get; private set; }

        public void ChangePrimaryPhoneNumber(PhoneNumber newPrimaryPhoneNumber)
        {
            PrimaryPhoneNumber = newPrimaryPhoneNumber;
        }
        public void AddAlternatePhoneNumber(PhoneNumber newAlternatePhoneNumber)
        {
            if(PrimaryPhoneNumber==newAlternatePhoneNumber)
                throw new PhoneAlreadyAddedAsPrimary(newAlternatePhoneNumber);

            if(_alternatePhoneNumbers.Contains(newAlternatePhoneNumber))
                return;

            _alternatePhoneNumbers.Add(newAlternatePhoneNumber);
        }
        public void RemoveAlternatePhoneNumber(PhoneNumber phoneNumberToRemove)
        {
            if(phoneNumberToRemove==null) return;
                _alternatePhoneNumbers.Remove(phoneNumberToRemove);
        }
        public void ClearAlternatePhoneNumbers()
        {
            _alternatePhoneNumbers.Clear();
        }

        public void ChangePrimaryEmail(EmailAddress newEmail)
        {
            PrimaryEmail = newEmail;
        }
        public void AddAlternateEmail(EmailAddress newEmail)
        {
            if (PrimaryEmail == newEmail)
                throw new EmailAlreadyAddedAsPrimary(newEmail);

            if (_alternateEmailAddresses.Contains(newEmail))
                return;

            _alternateEmailAddresses.Add(newEmail);
        }
        public void RemoveAlternateEmails(EmailAddress emailToRemove)
        {
            if(emailToRemove==null) return;
            _alternateEmailAddresses.Remove(emailToRemove);
        }
        public void ClearAlternateEmails()
        {
            _alternateEmailAddresses.Clear();
        }

        public void SetPhoto(ContactPhoto photo)
        {
            Photo = photo;
        }

        public void SetPersonalData(ContactPersonalData personalData)
        {
            PersonalData = personalData;
        }

    }
}
