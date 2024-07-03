using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("notification")]
    public class Notification
    {
        public Notification()
        {
        }

        public Notification(Person recipient, string message)
        {
            Recipient = recipient;
            Message = message;
        }

        [Key]
        [Column("id_mess")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("id_recipient")]
        [Required]
        public Person Recipient { get; set; }

        [MaxLength(300)]
        [Required]
        [Column("message")]
        public string Message { get; set; }
    }
}
