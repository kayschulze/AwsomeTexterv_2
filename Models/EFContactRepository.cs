using System;
using System.Linq;

namespace AwesomeTexter.Models
{
    public class EFContactRepository : IContactRepository
    {
        ApplicationDbContext db;

        public EFContactRepository(ApplicationDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new ApplicationDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Contact> Contacts
        {
            get { return db.Contacts; }
        }

        public Contact Edit(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return contact;
        }

        public void Remove(Contact contact)
        {
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        public Contact Save(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return contact;
        }
    }
}
