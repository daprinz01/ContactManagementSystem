using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagementSystem.Model
{
    public class Contacts 
    {
        
        //public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }
    }
    public class ContactDb : IContactDb
    {
        List<Contacts> db;
        public ContactDb()
        {
            List<Contacts> contact = new List<Contacts>();
            this.db = contact;
        }
        public void AddContact(Contacts contacts)
        {
            db.Add(contacts);
        }
        
        public List<Contacts> contacts { get; set; }
    }
}
