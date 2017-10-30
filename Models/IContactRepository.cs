using System.Linq;

namespace AwesomeTexter.Models
{
    public interface IContactRepository
    {
        IQueryable<Contact> Contacts { get; }
        Contact Save(Contact contact);
        Contact Edit(Contact contact);
        void Remove(Contact contact);
    }
}
