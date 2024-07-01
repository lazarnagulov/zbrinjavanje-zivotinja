using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Core.Service
{
    public class PostService(IPostRepository postRepository)
    {
        public List<Post> GetAll() => postRepository.GetAll();
        public List<Post> GetAcceptedPosts() => postRepository.GetAcceptedPosts();


    }
}
