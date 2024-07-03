using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("association")]
    public class Association
    {
        public Association()
        {
        }

        public Association(string name, string accountNumber, string? websiteLink = null)
        {
            Name = name;
            AccountNumber = accountNumber;
            WebsiteLink = websiteLink;
        }

        [Key]
        [Column("id_assoc")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(30)]
        [Required]
        [Column("assoc_name")]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        [Column("assoc_acc_number")]
        public string AccountNumber { get; set; }

        [MaxLength(50)]
        [Column("assoc_website")]
        public string? WebsiteLink { get; set; }
    }
}
