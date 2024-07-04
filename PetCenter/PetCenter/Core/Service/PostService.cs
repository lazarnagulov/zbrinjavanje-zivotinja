using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Stores;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Domain.State;

namespace PetCenter.Core.Service
{
    public class PostService(IPostRepository postRepository, ICommentRepository commentRepository, AuthenticationStore authenticationStore)
    {
        public bool Insert(Post post) => postRepository.Insert(post);
        public bool Delete(Post post) => postRepository.Delete(post);
        public Post? GetById(Guid id) => postRepository.GetById(id);
        public bool Update(Post post) => postRepository.Update(post);

        public List<Post> GetAll()
        {
            var posts = postRepository.GetAll();
            posts.ForEach(post => post.State.Context = post);
            return posts;
        }

        public List<Post> GetAccepted()
        {
            var posts = postRepository.GetAccepted();
            posts.ForEach(post => post.State.Context = post);
            return posts;
        }

        public List<Post> GetOnHold() => postRepository.GetOnHold();

        public int AddLike(Guid id)
        {
            var post = GetById(id);
            var user = authenticationStore.LoggedUser;
            Trace.Assert(post is not null);
            Trace.Assert(user is not null);

            if (post.Likes.Contains(user))
            {
                post.RemoveLike(user);

            }
            else
            {
                post.AddLike(user);
            }
            postRepository.Update(post!);
            return post.LikeCount;
        }

        public void AddComment(Guid id, Comment comment)
        {
            var post = GetById(id);
            var user = authenticationStore.LoggedUser;
            Trace.Assert(post is not null);
            Trace.Assert(user is not null);

            commentRepository.Insert(comment);
            post?.AddComment(comment);
            postRepository.Update(post!);
        }

        public void DeleteComment(Guid commentId)
        {
            var comment = commentRepository.GetById(commentId);
            Trace.Assert(comment is not null);
            commentRepository.Delete(comment);
        }
    }
}
