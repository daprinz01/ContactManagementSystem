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
            contacts.Add(
                new Contacts { Email = "okechukwuprince@hotmail.com", FirstName = "Okechukwu", LastName = "Prince", PhoneNumber = "+2348160273875" }
                );
            contacts.Add(new Contacts { Email = "daprinz.op@gmail.com", FirstName = "Daprinz", LastName = "Op", PhoneNumber = "+2348134720875" });
            return contacts;
        }

        [HttpGet("{firstName}")]
        public ActionResult<Contacts> Get(String firstName)
        {
            Contacts contact = new Contacts();

            contact = db.contacts.Where(m => m.FirstName == firstName).FirstOrDefault();
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
                    db.contacts.Add(item);
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