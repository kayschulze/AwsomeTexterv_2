using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeTexter.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeTexter.Controllers
{
    public class ContactsController : Controller
    {
        private IContactRepository contactRepo;

        public ContactsController(IContactRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.contactRepo = new EFContactRepository();
            }
            else
            {
                this.contactRepo = thisRepo;    
            }

        }
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            var contactList = db.Contacts.ToList();
            return View(contactList);
        }
        public IActionResult Details(int id)
        {
            var contact = db.Contacts.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
