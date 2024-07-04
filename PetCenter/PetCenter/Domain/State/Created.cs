using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    internal class Created : PostState
    {
        public Created() { }
        public Created(Post context) : base(context)
        {
        }

        public override void Initialize(AccountType type)
        {
            switch (type)
            {
                case AccountType.Member:
                    Context.ChangeState(new OnHold());
                    break;
                case AccountType.Volunteer:
                    Context.ChangeState(new Accepted());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), $"Unexpected account type: {type}");
            }
        }
        public override string ToString() => nameof(Created);

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

        public override void ReturnAnimal()
        {
        }

        public override void GiveAnimalTemporaryAccommodation()
        {
        }
        
    }
}
