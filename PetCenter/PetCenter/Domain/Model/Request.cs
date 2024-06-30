using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Request(Person author)
    {
        public Person Author { get; set; } = author;
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int VotesFor { get; set; } = 0;
        public int VotesAgainst { get; set; } = 0;
        private readonly List<Person> _voters = [];
        public IReadOnlyCollection<Person> Voters => _voters;

        public void AddVoter(Person person) => _voters.Add(person);
        public void RemoveVoter(Person person) => _voters.Remove(person);
    }
}
