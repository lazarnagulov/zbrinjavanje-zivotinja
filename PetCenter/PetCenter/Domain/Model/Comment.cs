using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Comment(Person author, string text)
    {
        public Person Author { get; set; } = author;
        public string Text { get; set; } = text;
    }
}
