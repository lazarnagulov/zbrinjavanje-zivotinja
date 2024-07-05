using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    public class Accepted : PostState
    {
        public Accepted() { }
        public Accepted(Post context) : base(context)
        {
        }
        public override void HidePost() => Context.ChangeState(new Hidden(Context));
        public override void AdoptAnimal() => Context.ChangeState(new Adopted(Context));
        public override void GiveAnimalTemporaryAccommodation()
            => Context.ChangeState(new TemporaryAccommodation(Context));
        public override string ToString() => nameof(Accepted);

        public override void AcceptPost()
        {
        }

        public override void DeclinePost()
        {
        }

        public override void ShowPost()
        {
        }

        public override void ReturnAnimal()
        {
        }

        public override void Initialize(AccountType type)
        {
        }
        
    }
}
