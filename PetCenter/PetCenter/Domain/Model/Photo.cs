using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Photo(string url, string description)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; } = url;
        public string Description { get; set; } = description;
    }
}
