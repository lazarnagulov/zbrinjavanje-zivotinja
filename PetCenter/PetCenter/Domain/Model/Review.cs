using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("review")]
    public class Review
    {
        public Review()
        {
        }

        public Review(int grade, string comment)
        {
            Grade = grade;
            Comment = comment;
        }

        [Key]
        [Column("id_review")]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Column("grade")]
        [Required]
        public int Grade { get; set; }

        [MaxLength(300)]
        [Required]
        [Column("comment_r")]
        public string Comment { get; set; }
    }
}
