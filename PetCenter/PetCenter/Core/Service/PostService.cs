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
        public bool Insert(Post post) => postRepository.Insert(post);
        public bool Delete(Post post) => postRepository.Delete(post);
        public Post? GetById(Guid id) => postRepository.GetById(id);
        public List<Post> GetAll() => postRepository.GetAll();
        public List<Post> GetAccepted() => postRepository.GetAccepted();
        public List<Post> GetOnHold() => postRepository.GetOnHold();
    }
}
