using System;
using System.Collections.Generic;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Repositories
{
    public static class InitData
    {

        public static IEnumerable<ContactInfo> GetDebugData()
        {
            return new List<ContactInfo>
            {
                CreateAnnaKowalska(),
                CreateCarlosAlberto(),
                CreateJanKowalski()
            };
        }


        private static ContactInfo CreateJanKowalski()
        {
            ContactInfo.Builder builder = new ContactInfo
                .Builder(Guid.NewGuid(), "Jan Kowalski", "123-456-789");

            builder.WithPrimaryEmail(new EmailAddress("jan.kowalski@mini.com"));

            List<EmailAddress> alternateEmails = new List<EmailAddress>();
            alternateEmails.Add(new EmailAddress("jankowalski@tmp.com"));
            alternateEmails.Add(new EmailAddress("jkowalski@mini.com"));
            builder.WithAlternateEmails(alternateEmails)
                .WithAdress(new Address("Warszawa", "Testowa", "666", "777"))
                .WithAlternatePhoneNumbers(new List<PhoneNumber>
                {
                    new PhoneNumber("111-222-333"),
                    new PhoneNumber("444-555-666")
                })
                .WithPersonalData(new ContactPersonalData(new FirstNames("Jan"), new LastNames("Kowalski"),
                    new DateTime(1987, 1, 1), Sex.Male, RelationType.Friend | RelationType.Family));
            return builder.Build();
        }
        private  static ContactInfo CreateCarlosAlberto()
        {
            ContactInfo.Builder builder = new ContactInfo
                .Builder(Guid.NewGuid(), "Carlos", "223-456-789");

            builder.WithPrimaryEmail(new EmailAddress("carlos.alberto.valder.sanchez@mini.com"));

            builder.WithAlternateEmails(new EmailAddress[0])
                .WithAdress(new Address("Warszawa", "Hiszpańska", "666", "777"))
                .WithPersonalData(new ContactPersonalData(new FirstNames("Carlos", "Alberto"),
                    new LastNames("Valder", "Sanchez"),
                    new DateTime(1985, 1, 1), Sex.Unknown, RelationType.Collegue));
            return builder.Build();
        }
        private static ContactInfo CreateAnnaKowalska()
        {
            ContactInfo.Builder builder = new ContactInfo
                .Builder(Guid.NewGuid(), "Ania", "673-456-789");

            builder.WithPrimaryEmail(new EmailAddress("ania.kowalska@mini.com"));

            builder.WithAlternateEmails(new List<EmailAddress>())
                .WithAlternateEmails(new[]
                    {new EmailAddress("test@gmail.com"), new EmailAddress("abc@asdd.com")});
            return builder.Build();
        }
    }
}
