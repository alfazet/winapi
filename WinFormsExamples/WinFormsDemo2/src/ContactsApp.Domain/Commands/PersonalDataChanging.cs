using System;
using System.Threading.Tasks;
using ContactsApp.Domain.Events;
using ContactsApp.Domain.Repositories;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Commands
{
    public class PersonalDataChanging:IDomainCommand
    {
        public PersonalDataChanging(Guid aggregateId, ContactPersonalData personalData)
        {
            AggregateId = aggregateId;
            PersonalData = personalData;
        }
        public Guid AggregateId { get; }
        public ContactPersonalData PersonalData { get; }
    }


    public class PersonalDataChangingHandler : IDomainCommandHandler<PersonalDataChanging>
    {
        public IContactInfoRepository Repository { get; }
        public IEventDomainDispatcher EventDomainDispatcher { get; }

        public PersonalDataChangingHandler(IContactInfoRepository repository,
            IEventDomainDispatcher eventDomainDispatcher)
        {
            Repository = repository;
            EventDomainDispatcher = eventDomainDispatcher;
        }
        public async Task Handle(PersonalDataChanging command)
        {
            var obj = await Task.Run(() => Repository.GetById(command.AggregateId));
            obj.SetPersonalData(command.PersonalData);
            await Task.Run(() => Repository.Update(obj));
            EventDomainDispatcher.Dispatch(new PersonalDataChanged(obj.Id, obj.PersonalData));
        }
    }
}
