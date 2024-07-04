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
    public class Adopted : PostState
    {
        public Adopted() { }
        public Adopted(Post context) : base(context)
        {
        }

        public override void ReturnAnimal() => Context.ChangeState(new Accepted(Context));
        public override string ToString() => nameof(Adopted);

        public override void AcceptPost()
        {
        }

        public override void DeclinePost()
        {
        }

        public override void HidePost()
        {
        }

        public override void ShowPost()
        {
        }

        public override void AdoptAnimal()
        {
        }

        public override void GiveAnimalTemporaryAccommodation()
        {
        }

        public override void Initialize(AccountType type)
        {
        }
    }
}
