using System;

namespace ContactsApp.Domain.Aggregates.Exceptions
{
    public class BuilderAlreadyCreateObject:Exception
    {
        public BuilderAlreadyCreateObject(): base()
        {

        }
    }
}
