using System;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Events
{
    public class PhotoChanged : IDomainEvent
    {
        public PhotoChanged(Guid id, ContactPhoto contactPhoto)
        {
            CustomInfoId = id;
            Photo = contactPhoto;
        }
        public Guid CustomInfoId { get; }
        public ContactPhoto Photo { get; }
    }
}