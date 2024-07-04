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
    public class OnHold : PostState
    {
        public OnHold() { }
        public OnHold(Post context) : base(context)
        {
        }
        public override void AcceptPost() => Context.ChangeState(new Accepted(Context));
        public override void DeclinePost() => Context.ChangeState(new Declined(Context));
        public override string ToString() => nameof(OnHold);

        public override void HidePost()
        {
        }

        public override void ShowPost()
        {
        }

        public override void AdoptAnimal()
        {
        }

        public override void ReturnAnimal()
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
