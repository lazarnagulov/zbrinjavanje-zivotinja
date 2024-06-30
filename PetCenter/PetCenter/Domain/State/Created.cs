﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.State
{
    internal class Created(Post context) : PostState(context)
    {
        public override void Initialize()
        { }

        public override void AcceptPost()
        { }

        public override void DeclinePost()
        { }

        public override void HidePost()
        { }

        public override void ShowPost()
        { }

        public override void AdoptAnimal()
        { }

        public override void GiveAnimalTemporaryAccommodation()
        { }
    }
}