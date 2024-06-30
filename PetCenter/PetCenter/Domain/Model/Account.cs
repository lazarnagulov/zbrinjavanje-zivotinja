using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Account(string username, string email, string password)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Username { get; set; } = username;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public Person? Person { get; set; }
    }
}
