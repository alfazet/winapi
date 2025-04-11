using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsApp.Domain.ValueObjects
{
    public class LastNames : ValueObject<LastNames>
    {
        public string LastName { get; }
        private string[] _additionalLastsName;
        private bool _useDashForTwoLastNames;

        public bool HasMultipleLastNames => _additionalLastsName != null && _additionalLastsName.Length > 0;
        public bool UseDashBetweenNames => HasMultipleLastNames && _useDashForTwoLastNames;
        public IEnumerable<string> AdditionalLastNames => _additionalLastsName.AsEnumerable();


        public LastNames(string lastName)
                : this(lastName, null)
        {
        }

        public LastNames(string firstLastName, string secondLastName, bool useDash)
            :this(firstLastName,secondLastName)
        {
            _useDashForTwoLastNames= useDash;
        }

        public LastNames(string lastName, params string[] additionalLastName)
        {
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentNullException(nameof(lastName));
            LastName = lastName;
            _additionalLastsName = additionalLastName;
            _useDashForTwoLastNames = false;

        }

        private string Format()
        {
            StringBuilder builder=new StringBuilder();
            builder.Append(LastName);
            if (UseDashBetweenNames)
            {
                builder.Append("-");
            }
            else
            {
                builder.Append(" ");
            }

            if (AdditionalLastNames != null)
            {
                foreach (var additionalLastName in AdditionalLastNames)
                {
                    if (!builder.ToString().EndsWith(" ")) builder.Append(" ");
                    builder.Append(additionalLastName);
                }
            }

            return builder.ToString();

        }

        public override string ToString()
        {
            return Format();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LastName;
            yield return _additionalLastsName;
            yield return _useDashForTwoLastNames;
        }
    }
}
