using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagementSystem.DataSource;
using ContactManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementSystem.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactDbContext db;

        public ContactController(ContactDbContext contactDb)
        {
            db = contactDb;
            
        }
        // GET: Contact
        [HttpGet]
        public ActionResult<List<Contacts>> Get()
        {
            List<Contacts> contacts = new List<Contacts>();
            foreach (var item in db.contacts)
            {
                Contacts contact = new Contacts();
                contact.Email = item.Email;
                contact.FirstName = item.FirstName;
                contact.LastName = item.LastName;
                contact.PhoneNumber = item.PhoneNumber;
                contacts.Add(contact);
            }
            return contacts;
        }

        [HttpGet("{firstName}")]
        public ActionResult<Contacts> Get(String firstName)
        {
            Contacts contact = new Contacts();

            //contact =(Contacts) db.contacts.Where(m => m.FirstName == firstName).FirstOrDefault();
            return contact;
        }

        
        // POST: Contact/Create
        [HttpPost]
        public ActionResult<String> Post([FromBody] List<Contacts> contact)
        {
            try
            {
                foreach(Contacts item in contact)
                {
                    Contact myContact = new Contact();
                    myContact.FirstName = item.FirstName;
                    myContact.LastName = item.LastName;
                    myContact.Email = item.Email;
                    myContact.PhoneNumber = item.PhoneNumber;
                    db.contacts.Add(myContact);
                }
                db.SaveChanges();
                
                return "Success";
            }
            catch(Exception e)
            {
                return "Error occured while creating contact with exception \n" + e.Message;
            }
        }

        
        

        
        
    }
}