using System.Threading.Tasks;

namespace ContactsApp.Domain.Commands
{
    public interface IDomainCommandHandler<in T>
        where T : IDomainCommand
    {
        Task Handle(T command);
    }
}