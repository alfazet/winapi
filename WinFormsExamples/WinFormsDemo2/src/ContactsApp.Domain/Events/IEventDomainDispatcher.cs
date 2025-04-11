using System.Collections.Generic;
using System.Reflection;
using ContactsApp.Domain.Commands;

namespace ContactsApp.Domain.Events
{
    public interface IEventDomainDispatcher
    {
        void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;
    }

    public interface ICommandDomainDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : IDomainCommand;
    }


    //public class EventDomainDispatcher:IEventDomainDispatcher
    //{
    //    public EventDomainDispatcher()
    //    {

    //    }

    //    private IEnumerable<IDomainEventHandler<TEntity>> GetHandlers<TEntity>() where TEntity:IDomainEvent
    //    {
    //        Get

    //    }

    //    public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
    //    {

    //    }
    //}
}