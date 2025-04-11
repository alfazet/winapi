using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ContactsApp.Domain.Shared;

namespace ContactsApp.Domain.ValueObjects
{
    public class ContactPersonalData:ValueObject<ContactPersonalData>
    {
        public FirstNames FirstNames { get; }
        public LastNames LastNames { get; }
        public DateTime? DateOfBirth { get; private set; }
        public Sex Sex { get; private set; }
        public RelationType RelationType { get; private set; }

        public ContactPersonalData(FirstNames firstNames, LastNames lastNames)
        {
            FirstNames = firstNames ?? throw new ArgumentNullException(nameof(firstNames));
            LastNames = lastNames ?? throw new ArgumentNullException(nameof(lastNames));
        }

        public ContactPersonalData(FirstNames firstNames, LastNames lastNames,DateTime? dateOfBirth=null,Sex sex=Sex.Unknown,RelationType relationType=RelationType.None)
        {
            FirstNames = firstNames ?? throw new ArgumentNullException(nameof(firstNames));
            LastNames = lastNames ?? throw new ArgumentNullException(nameof(lastNames));
            DateOfBirth = dateOfBirth;
            Sex = sex;
            RelationType = relationType;
        }
        
        //Immutable type in this scenerio
        public ContactPersonalData ChangeDateOfBirth(DateTime? dateOfBirth)
        {
            return new ContactPersonalData(FirstNames,LastNames,dateOfBirth,Sex,RelationType);
        }

        //Immutable type in this scenerio
        public ContactPersonalData ChangeSex(Sex sex)
        {
            return new ContactPersonalData(FirstNames, LastNames, DateOfBirth, sex, RelationType);
        }

        //Immutable type in this scenerio
        public ContactPersonalData ChangeRelationType(RelationType relationType)
        {
            return new ContactPersonalData(FirstNames, LastNames, DateOfBirth, Sex, relationType);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LastNames;
            yield return FirstNames;
            yield return Sex;
            yield return DateOfBirth;
            yield return RelationType;
        }

        public override string ToString()
        {
            return $"{FirstNames} {LastNames} : {Sex.GetDescription()} born at {FormatDateOfBrith()} related with me as: {FormatRelationship()} ";
        }

        public string FormatRelationship()
        {
            StringBuilder stringBuilder=new StringBuilder();
            foreach (var flag in Enum.GetValues(RelationType.GetType()).Cast<RelationType>())
            {
                if (flag!=RelationType.None && RelationType.HasFlag(flag))
                {
                    if (stringBuilder.Length > 0)
                        stringBuilder.Append(" and ");
                    stringBuilder.Append(flag.GetDescription());
                }
            }

            return stringBuilder.ToString();
        }

        private string FormatDateOfBrith()
        {
            return DateOfBirth.HasValue ? DateOfBirth.Value.ToLongDateString() : "Unknown";
        }
    }

    public enum Sex
    {
        [Description("Unkown")]
        Unknown=0,
        [Description("Female")]
        Female =1,
        [Description("Male")]
        Male =2,
    }

    [Flags]
    public enum RelationType
    {
        [Description("None")]
        None,
        [Description("Part of family")]
        Family,
        [Description("Dear friend")]
        Friend,
        [Description("Just a collegue")]
        Collegue,
        [Description("Work with this person")]
        WorkAssosiate,
        [Description("He stock me!!!!!")]
        Stocker
    }
}
