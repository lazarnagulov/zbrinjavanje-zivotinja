﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.RepositoryInterfaces
{
    public interface IPostRepository : ICrud<Post>
    {
        List<Post> GetAccepted();
        List<Post> GetOnHold();
        List<Post> GetAcceptedWithHidden();
        List<Post> GetAllIncluded();
    }
}
