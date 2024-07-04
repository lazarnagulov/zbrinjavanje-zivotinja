using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    public class Adopted : PostState
    {
        public Adopted() { }
        public Adopted(PostService context) : base(context)
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
            throw new NotImplementedException();
        }

        public override void AdoptAnimal(Post post)
        {
            throw new NotImplementedException();
        }

        public override void ReturnAnimal(Post post)
        {
            Context.ChangeState(post,new Accepted(Context));
        }

        public override void GiveAnimalTemporaryAccommodation(Post post)
        {
            throw new NotImplementedException();
        }

        public override void Initialize(Post post)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => nameof(Adopted);
    }
}
