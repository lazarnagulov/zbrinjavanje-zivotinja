using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class AnimalType(string type, string race)
    {
        public string Type { get; set; } = type;
        public string Race { get; set; } = race;
    }
}
