using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Domain.Repositories
{
    public interface IContactInfoRepository
    {
        IEnumerable<ContactInfo> GetAll();
        ContactInfo GetById(Guid id);
        void Update(ContactInfo contactInfo);
    }
    public class ContactInfoRepository:IContactInfoRepository
    {
        static readonly List<ContactInfo> DataSource;

        static ContactInfoRepository()
        {
            DataSource = InitData.GetDebugData().ToList();
        }

        public IEnumerable<ContactInfo> GetAll()
        {
            return DataSource;
        }

        public ContactInfo GetById(Guid id)
        {
            return DataSource.FirstOrDefault(di => di.Id == id);
        }

        public void Update(ContactInfo contactInfo)
        {
            var obj=GetById(contactInfo.Id);
            DataSource.Remove(obj);
            DataSource.Add(contactInfo);
        }
    }
}
