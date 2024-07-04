using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    public class Accepted : PostState
    {
        public Accepted()
        {

        }

        public Accepted(PostService context) : base(context)
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
            Context.ChangeState(post, new Hidden(Context));
        }

        public override void ShowPost(Post post)
        {
            throw new NotImplementedException();
        }

        public override void AdoptAnimal(Post post)
        {
            Context.ChangeState(post, new Adopted(Context));
        }

        public override void ReturnAnimal(Post post)
        {
            throw new NotImplementedException();
        }

        public override void GiveAnimalTemporaryAccommodation(Post post)
        {
            Context.ChangeState(post, new TemporaryAccommodation(Context));
        }

        public override void Initialize(Post post)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => nameof(Accepted);

        
    }
}
