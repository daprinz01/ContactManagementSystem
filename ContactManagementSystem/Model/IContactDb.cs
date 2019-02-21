using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagementSystem.Model
{
    public interface IContactDb
    {
        void AddContact(Contacts contacts);
    }
}
