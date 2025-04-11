using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Events
{
    public class PersonalDataChanged:IDomainEvent
    {
        public PersonalDataChanged(Guid aggregateId, ContactPersonalData data)
        {
            PersonalData = data;
            AggregateId = aggregateId;
        }
        public Guid AggregateId { get; }
        public ContactPersonalData PersonalData { get; }
    }


}
