using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    public class Hidden : PostState
    {
        public Hidden() { }
        public Hidden(PostService context) : base(context)
        {
        }

        public override void AcceptPost(Post post)
        {
            throw new NotImplementedException();
        }

        public override void DeclinePost(Post post)
        {
            throw new NotImplementedException();
        }

        public override void HidePost(Post post)
        {
            throw new NotImplementedException();
        }

        public override void ShowPost(Post post)
        {
            Context.ChangeState(post, new Accepted(Context));
        }

        public override void AdoptAnimal(Post post)
        {
            throw new NotImplementedException();
        }

        public override void ReturnAnimal(Post post)
        {
            throw new NotImplementedException();
        }

        public override void GiveAnimalTemporaryAccommodation(Post post)
        {
            throw new NotImplementedException();
        }

        public override void Initialize(Post post)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => nameof(Hidden);

    }
}
