using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    internal class Created : PostState
    {
        public Created() { }
        public Created(Post post) { }
        public Created(PostService context) : base(context)
        {
        }

        public override void Initialize(Post post)
        { }

        public override void AcceptPost(Post post)
        { }

        public override void DeclinePost(Post post)
        { }

        public override void HidePost(Post post)
        { }

        public override void ShowPost(Post post)
        { }

        public override void AdoptAnimal(Post post)
        { }

        public override void ReturnAnimal(Post post)
        { }

        public override void GiveAnimalTemporaryAccommodation(Post post)
        { }

        public override string ToString() => nameof(Created);

        
    }
}
