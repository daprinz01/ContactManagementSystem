using ContactManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagementSystem.DataSource 
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {

        }
        public DbSet<Contacts> contacts { get; set; }
    }

    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }
    }
}
