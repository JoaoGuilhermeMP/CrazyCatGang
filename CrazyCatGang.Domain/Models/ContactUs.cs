using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCatGang.Domain.Models
{
    public class Contacts
    {
        public int Id { get; set; }  // Chave primária
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }
        public string ContactReason { get; set; }
        public DateTime ContactDate { get; set; }

        public User User { get; set; }
    }
}
