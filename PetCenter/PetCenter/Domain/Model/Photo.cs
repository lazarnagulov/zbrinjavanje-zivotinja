using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("photo")]
    public class Photo
    {
        public Photo()
        {
        }
        public Photo(string url, string description)
        {
            Url = url;
            Description = description;
        }

        [Key]
        [Column("id_photo")]
        public Guid Id { get; set; } = Guid.NewGuid();
       
        [Required]
        [Column("photo_url")]
        public string Url { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("photo_desc")]
        public string Description { get; set; }
    }
}
