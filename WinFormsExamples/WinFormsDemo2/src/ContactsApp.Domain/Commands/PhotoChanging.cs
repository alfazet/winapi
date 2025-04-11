using System;
using System.IO;
using System.Threading.Tasks;
using ContactsApp.Domain.Events;
using ContactsApp.Domain.Repositories;
using ContactsApp.Domain.ValueObjects;

namespace ContactsApp.Domain.Commands
{
    public class PhotoChanging : IDomainCommand
    {
        public PhotoChanging(Guid id, byte[] raw, string fileName)
        {
            Id = id;
            Raw = raw;
            FileName = fileName;
        }
        public Guid Id { get; }
        public byte[] Raw { get; }
        public string FileName { get; }
    }

    public class PhotoChangingDomainHandler : IDomainCommandHandler<PhotoChanging>
    {
        public IContactInfoRepository Repository { get; }
        public IEventDomainDispatcher EventDomainDispatcher { get; }

        public PhotoChangingDomainHandler(IContactInfoRepository repository, IEventDomainDispatcher eventDomainDispatcher)
        {
            Repository = repository;
            EventDomainDispatcher = eventDomainDispatcher;
        }

        public async Task Handle(PhotoChanging command)
        {
            var obj = await Task.Run(() => Repository.GetById(command.Id));
            Path.GetExtension(command.FileName);
            obj.SetPhoto(new ContactPhoto(command.Raw, ContactPhoto.TypeFromFileName(command.FileName)));
            await Task.Run(() => Repository.Update(obj));
            EventDomainDispatcher.Dispatch(new PhotoChanged(obj.Id,obj.Photo));
        }

    }
}
