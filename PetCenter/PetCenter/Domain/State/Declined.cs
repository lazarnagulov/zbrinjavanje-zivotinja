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
    internal class Declined : PostState
    {
        public Declined() { }
        public Declined(Post context) : base(context)
        {
        }
        public override string ToString() => nameof(Declined);


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

        public override void Initialize(AccountType type)
        {
        }
    }
}
