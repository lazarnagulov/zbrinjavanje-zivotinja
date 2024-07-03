using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("comment")]
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(Person author, string text)
        {
            Author = author;
            Text = text;
        }


        [Key]
        [Column("id_comment")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("person_author_c")]
        public Person Author { get; set; }

        [MaxLength(300)]
        [Required]
        [Column("comment_text")]
        public string Text { get; set; }
    }
}
