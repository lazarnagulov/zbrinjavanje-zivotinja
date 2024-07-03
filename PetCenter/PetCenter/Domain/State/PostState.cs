using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    [Table("post_state")]
    public abstract class PostState
    {

        public Guid Id { get; set; }
        // TODO: Change to PostService
        protected Post Context;

        protected PostState()
        {
            
        }
        protected PostState(Post context)
        {
            Context = context;
        }

        public abstract void AcceptPost();
        public abstract void DeclinePost();
        public abstract void HidePost();
        public abstract void ShowPost();
        public abstract void AdoptAnimal();
        public abstract void ReturnAnimal();
        public abstract void GiveAnimalTemporaryAccommodation();
        public abstract void Initialize();

    }
}
