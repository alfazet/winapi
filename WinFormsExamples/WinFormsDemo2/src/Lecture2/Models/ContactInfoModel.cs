using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using ContactsApp.Domain;
using ContactsApp.Domain.ValueObjects;

namespace Lecture2.Models
{
    public class ContactInfoModel
    {
        public ContactInfoModel(ContactInfo contactInfo)
        {
            if (contactInfo == null) throw new ArgumentNullException(nameof(contactInfo));
            Id = contactInfo.Id;
            Name = contactInfo.Name;
            PhoneNumber = contactInfo.PrimaryPhoneNumber?.ToString();

            if (contactInfo.Photo != null)
            {
                using (var stream = new MemoryStream(contactInfo.Photo.Image))
                {
                    Picture = Image.FromStream(stream);
                }
            }

            FirstName = contactInfo.PersonalData?.FirstNames?.ToString();
            LastName = contactInfo.PersonalData?.LastNames?.ToString();
            if (contactInfo.PersonalData != null)
            {
                SexDisplay = "Sex: ";
                switch (contactInfo.PersonalData.Sex)
                {
                    case Sex.Female:
                        SexDisplay += "Female";
                        break;
                    case Sex.Male:
                        SexDisplay += "Male";
                        break;
                    default:
                        SexDisplay += "Unknow";
                        break;
                }
            }


            if (contactInfo.Adress != null)
            {
                AddressDisplay = contactInfo.Adress.ToString();
            }

            if (contactInfo.PersonalData != null && contactInfo.PersonalData.DateOfBirth.HasValue)
            {
                DateOfBirthDisplay = "Born on: " + contactInfo.PersonalData.DateOfBirth.Value.ToShortDateString();
            }

            Emails = new List<string>();
            if (contactInfo.PrimaryEmail != null)
            {
                Emails.Add(contactInfo.PrimaryEmail.Email);
            }

            if (contactInfo.AltenrnateEmails != null)
            {
                Emails.AddRange(contactInfo.AltenrnateEmails.Select(c=>c.Email));
            }

            if (contactInfo.AlternatePhoneNumbers != null)
            {
                AlterantePhonse=new List<string>();
                AlterantePhonse.AddRange(contactInfo.AlternatePhoneNumbers.Select(c=>c.FullNumber));
            }

            if (contactInfo.PersonalData != null)
                RelationshipDisplay = "Is my: "+contactInfo.PersonalData.FormatRelationship();
        }

        public Guid? Id { get; }
        public string Name { get;  }
        public string PhoneNumber { get;  }
        public string FirstName { get; }
        public string LastName { get; }
        public Image Picture { get;  }
        public string SexDisplay { get; }
        public string DateOfBirthDisplay { get; }
        public string AddressDisplay { get; }
        public string RelationshipDisplay { get; }
        public List<string> Emails { get; }
        public List<string> AlterantePhonse { get; }


    }

    public class ContactInfoEditModel
    {

    }
}

