using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    public abstract class PostState(Post context)
    {
        // TODO: Change to PostService
        protected Post Context = context;
        public abstract void AcceptPost();
        public abstract void DeclinePost();
        public abstract void HidePost();
        public abstract void ShowPost();
        public abstract void AdoptAnimal();
        public abstract void GiveAnimalTemporaryAccommodation();
        public abstract void Initialize();

    }
}
