using System;
using System.Threading.Tasks;

namespace ContactsApp.Domain.Events
{
    public class ConsoleLogger : IDomainEventHandler<PhotoChanged>, IDomainEventHandler<PersonalDataChanged>
    {
        public Task Handle(PhotoChanged @event)
        {
            return Task.Run(() => Console.WriteLine($"{@event.GetType().FullName} - {@event.CustomInfoId} - {@event.Photo}"));
        }

        public Task Handle(PersonalDataChanged @event)
        {
            return Task.Run(() => Console.WriteLine($"{@event.GetType().FullName} - {@event.AggregateId} - {@event.PersonalData}"));
        }
    }
}