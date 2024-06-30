using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.PostState
{
    public abstract class PostState(Post context)
    {
        private Post _context = context;
    }
}
