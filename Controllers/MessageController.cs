using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AwesomeTexter.Models;

namespace AwesomeTexter.Controllers
{
    public class MessageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }

        public IActionResult SendMessage()
        {
            var contactList = new ApplicationDbContext().Contacts.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            string phoneNumbers = newMessage.To;
            string[] phoneNumberArr = phoneNumbers.Trim().Split(',');

            var contactList = new ApplicationDbContext().Contacts
                .Where(c => phoneNumberArr.Contains(c.PhoneNumber)).ToList();
            newMessage.Send(contactList);
            return RedirectToAction("GetMessages");
        }
    }
}
