﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCatGang.Domain.Models
{
    public class User
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ICollection<Purchase>? Purchases { get; set; } = new List<Purchase>();
        public ICollection<Contacts>? Contacts { get; set; } = new List<Contacts>();

    }
}
