using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Review(int grade, string comment)
    {
        public int Grade { get; set; } = grade;
        public string Comment { get; set; } = comment;
    }
}
