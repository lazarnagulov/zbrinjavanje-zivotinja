using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Stores;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Core.Service
{
    public class PostService(IPostRepository postRepository, ICommentRepository commentRepository, AuthenticationStore authenticationStore)
    {
        public bool Insert(Post post) => postRepository.Insert(post);
        public bool Delete(Post post) => postRepository.Delete(post);
        public Post? GetById(Guid id) => postRepository.GetById(id);
        public List<Post> GetAll() => postRepository.GetAll();
        public List<Post> GetAccepted() => postRepository.GetAccepted();
        public List<Post> GetOnHold() => postRepository.GetOnHold();

        public void AddLike(Guid id)
        {
            if (authenticationStore.LoggedUser is { } user)
            {
                var post = GetById(id);
                if (post is not null)
                {
                    if (post.Likes.Contains(user))
                    {
                        post.RemoveLike(user);

                    }
                    else
                    {
                        post.AddLike(user);
                    }
                    var updated = postRepository.Update(post!);
                }
                else
                {
                    throw new UnreachableException("Post should exist here");
                }
            }
        }

        public void AddComment(Guid id, Comment comment)
        {
            if (authenticationStore.LoggedUser is { } user)
            {
                var post = GetById(id);
                if (post is not null)
                {
                    commentRepository.Insert(comment);
                    post?.AddComment(comment);
                    postRepository.Update(post!);
                }
                else
                {
                    throw new UnreachableException("Post should exist here");
                }
            }
        }
    }
}
