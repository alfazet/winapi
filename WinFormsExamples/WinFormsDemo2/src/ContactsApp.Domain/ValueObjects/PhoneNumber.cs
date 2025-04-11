using System.Collections.Generic;
using System.Text.RegularExpressions;
using ContactsApp.Domain.Shared;
using ContactsApp.Domain.ValueObjects.Exceptions;

namespace ContactsApp.Domain.ValueObjects
{
    public class PhoneNumber:ValueObject<PhoneNumber>
    {
        private readonly string _number;
        public string FullNumber => _number;

        private readonly Regex _regex=new Regex(Consts.PhoneRegex
            , RegexOptions.Compiled | RegexOptions.Singleline |RegexOptions.CultureInvariant);

        public PhoneNumber(string number)
        {
            if(!IsValid(number)) throw new InvalidPhoneNumberFormat(number);
            _number = number;
        }

        private bool IsValid(string number)
        {
            //libphonenumber ale napiszmy coś prostego;)
            return _regex.IsMatch(number);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _number;
        }

        public override string ToString()
        {
            return FullNumber;
        }
    }
}
