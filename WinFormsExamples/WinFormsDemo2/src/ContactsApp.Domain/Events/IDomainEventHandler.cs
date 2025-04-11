using System.Threading.Tasks;

namespace ContactsApp.Domain.Events
{
    public interface IDomainEventHandler<in T> 
        where T : IDomainEvent
    {
        Task Handle(T @event);
    }

}