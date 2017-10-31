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
            return View(contactList);
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            var contactList = new ApplicationDbContext().Contacts.ToList();
            newMessage.Send(contactList);
            return RedirectToAction("GetMessages");
        }
    }
}
