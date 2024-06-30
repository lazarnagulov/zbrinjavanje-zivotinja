using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;

namespace PetCenter.Domain.Model
{
    public class Account(string username, string email, string password, AccountType type)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Username { get; set; } = username;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public AccountType Type { get; set; } = type;
        public Person? Person { get; set; }
    }
}
