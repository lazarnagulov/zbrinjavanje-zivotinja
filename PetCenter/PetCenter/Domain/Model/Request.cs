using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("request")]
    public class Request
    {
        public Request()
        {

        }
        public Request(Person author)
        {
            Author = author;
        }
        [Key]
        [Column("id_req")]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [ForeignKey("person_req_author")]
        [Required]
        public Person Author { get; set; }

        [Required]
        [Column("creation_date_req")]
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [Column("for_promotion")]
        public int VotesFor { get; set; } = 0;

        [Required]
        [Column("against_promotion")]
        public int VotesAgainst { get; set; } = 0;

        private readonly List<Person> _voters = [];
        
        [Column("voters")]
        public IReadOnlyCollection<Person> Voters => _voters;
        
        public void AddVoter(Person person) => _voters.Add(person);
        public void RemoveVoter(Person person) => _voters.Remove(person);
    }
}
