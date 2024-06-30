using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetCenter.Domain.Model
{
    [Table("account")]
    public class Account
    {
        public Account()
        {
        }
        public Account(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }


        [Column("id_acc")]
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Column("username")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        
        [Column("email")]
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        
        [Column("password")]
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [ForeignKey("person_id_person")]
        public Person? Person { get; set; }
    }
}
