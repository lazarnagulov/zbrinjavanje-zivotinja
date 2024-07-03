using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    [Table("post_state")]
    public abstract class PostState
    {

        public Guid Id { get; set; }
        protected PostService Context;

        protected PostState()
        {
            
        }
        protected PostState(PostService context)
        {
            Context = context;
        }

        public void SetContext(PostService context)
        {
            Context = context;
        }

        public abstract void AcceptPost(Post post);
        public abstract void DeclinePost(Post post);
        public abstract void HidePost(Post post);
        public abstract void ShowPost(Post post);
        public abstract void AdoptAnimal(Post post);
        public abstract void ReturnAnimal(Post post);
        public abstract void GiveAnimalTemporaryAccommodation(Post post);
        public abstract void Initialize(Post post);

    }
}
