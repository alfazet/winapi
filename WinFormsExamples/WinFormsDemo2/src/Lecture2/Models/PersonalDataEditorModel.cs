using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Domain;
using ContactsApp.Domain.Shared;
using ContactsApp.Domain.ValueObjects;
using Lecture2.Models.Execeptions;

namespace Lecture2.Models
{
    public class PersonalDataEditorModel
    {

        public PersonalDataEditorModel(ContactInfo contactInfo)
            : this(contactInfo?.PersonalData)
        {
            if (contactInfo == null)
            {
                throw new ArgumentNullException(nameof(contactInfo));
            }
        }

        public PersonalDataEditorModel(ContactPersonalData personalData)
        {
            Relations =GetRelationTypes(RelationType.None);
            IsMale = false;
            IsFemale = false;
            IsUnknown = false;
            UseDashBeetwenLastNames = false;
            DateOfBirthNotSpecified = true;

            if (personalData != null)
            {
                FirstName = personalData.FirstNames?.Name;
                if (personalData.FirstNames?.AdditionalNames != null)
                    AdditionalFirstNames = string.Join(" ", personalData.FirstNames?.AdditionalNames);
                LastName = personalData.LastNames?.LastName;
                if (personalData.LastNames != null && personalData.LastNames.HasMultipleLastNames)
                {
                    AdditionalLastNames = string.Join(" ", personalData.LastNames.AdditionalLastNames);
                    UseDashBeetwenLastNames = personalData.LastNames.UseDashBetweenNames;
                }

                if (personalData.DateOfBirth.HasValue)
                {
                    DateOfBirth = personalData.DateOfBirth.Value;
                    DateOfBirthNotSpecified = false;
                }
                else
                {
                    DateOfBirth = DateTime.Today;
                    DateOfBirthNotSpecified = true;
                }

                Relations = GetRelationTypes(personalData.RelationType);
                switch (personalData.Sex)
                {
                    case Sex.Unknown:
                        IsUnknown = true;
                        break;
                    case Sex.Female:
                        IsFemale = true;
                        break;
                    case Sex.Male:
                        IsMale = true;
                        break;
                }
            }
        }

        private List<RelationItem> GetRelationTypes(RelationType @enum)
        {
            List<RelationItem> result = new List<RelationItem>();
            foreach (var flag in Enum.GetValues(@enum.GetType()).Cast<RelationType>())
            {
                result.Add(new RelationItem(flag, flag != RelationType.None && @enum.HasFlag(flag)));
            }

            return result;
        }
        public string FirstName { get; set; }
        public string AdditionalFirstNames { get; set; }
        public string LastName { get; set; }
        public string AdditionalLastNames { get; set; }
        public bool UseDashBeetwenLastNames { get; set; }
        public List<RelationItem> Relations { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool DateOfBirthNotSpecified { get; set; }

        public bool IsFemale { get; set; }
        public bool IsMale { get; set; }
        public bool IsUnknown { get; set; }


        public ContactPersonalData CreateValueObject()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                throw new NoRequiredDataProvidedForPersonalData(this);

            FirstNames firstNames = new FirstNames(FirstName, AdditionalFirstNames.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            var tmpLastAddNames = AdditionalLastNames.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            LastNames lastNames = UseDashBeetwenLastNames && tmpLastAddNames.Length == 1 ? new LastNames(LastName, AdditionalLastNames) : new LastNames(LastName, tmpLastAddNames);

            DateTime? dateOfBirth = DateOfBirthNotSpecified ? new DateTime?() : DateOfBirth;
            Sex sex = IsMale ? Sex.Male : (IsFemale ? Sex.Female : Sex.Unknown);
            RelationType relation = RelationType.None;
            foreach (var relationType in Relations.Where(c=>c.IsChecked))
            {
                relation = relation | relationType.RelationType;
            }

            ContactPersonalData contactPersonalData = new ContactPersonalData(firstNames, lastNames, dateOfBirth, sex, relation);
            return contactPersonalData;
        }


    }

    public class RelationItem
    {
        public RelationItem(RelationType relationType, bool @checked)
        {
            RelationType = relationType;
            Name = relationType.GetDescription();
            IsChecked = @checked;
        }

        public string Name { get; }
        public bool IsChecked { get; set; }
        public RelationType RelationType { get; }
    }
}
