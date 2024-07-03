using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    public class TemporaryAccommodation : PostState
    {
        public TemporaryAccommodation() { }
        public TemporaryAccommodation(Post context) : base(context)
        {
        }

        public override void AcceptPost()
        {
            throw new NotImplementedException();
        }

        public override void DeclinePost()
        {
            throw new NotImplementedException();
        }

        public override void HidePost()
        {
            throw new NotImplementedException();
        }

        public override void ShowPost()
        {
            throw new NotImplementedException();
        }

        public override void AdoptAnimal()
        {
            throw new NotImplementedException();
        }

        public override void ReturnAnimal()
        {
            Context.ChangeState(new Accepted(Context));
        }

        public override void GiveAnimalTemporaryAccommodation()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => nameof(TemporaryAccommodation);

    }
}
