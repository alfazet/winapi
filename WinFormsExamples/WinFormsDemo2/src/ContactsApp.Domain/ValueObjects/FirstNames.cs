using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp.Domain.ValueObjects
{
    public class FirstNames:ValueObject<FirstNames>
    {
        public string Name { get; }

        private string[] _additionalNames;
        public IEnumerable<string> AdditionalNames => _additionalNames.AsEnumerable();
        

        public FirstNames(string primaryFirstName)
            : this(primaryFirstName, null)
        {

        }

        public FirstNames(string primaryFirstName, params string[] additionalNames)
        {
            if(string.IsNullOrEmpty(primaryFirstName)) throw new ArgumentNullException(nameof(primaryFirstName));
            Name = primaryFirstName;
            if (additionalNames != null)
                _additionalNames = additionalNames;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return _additionalNames;
        }

        public override string ToString()
        {
            return _additionalNames!=null? $"{Name} {string.Join(" ",_additionalNames)}": Name;
        }
    }
}