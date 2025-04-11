using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp.Domain.ValueObjects
{

    //Light changed 
    //https://github.com/VaughnVernon/IDDD_Samples_NET/blob/master/iddd_common/Domain.Model/ValueObject.cs
    //with https://lostechies.com/jimmybogard/2007/06/25/generic-value-object-equality/
    public abstract class ValueObject<T>:IEquatable<T>
            where T: ValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            T other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            IEnumerable<object> fields = GetEqualityComponents();



            int startValue = 17;
            int multiplier = 59;

            int hashCode = startValue;



            foreach (object field in fields)
            {
                if (field != null)
                    hashCode = hashCode * multiplier + field.GetHashCode();
            }



            return hashCode;
        }

        public virtual bool Equals(T other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            var vo = other as ValueObject<T>;
            return GetEqualityComponents().SequenceEqual(vo.GetEqualityComponents());
        }


        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if (ReferenceEquals(x, null) && !ReferenceEquals(y, null)) return false;
            if (!ReferenceEquals(x, null) && ReferenceEquals(y, null)) return false;
            if (ReferenceEquals(x, null)) return true;

            return x.Equals(y);

        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {

            return !(x == y);

        }
    }
}
