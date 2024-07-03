﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Post> GetAll() => postRepository.GetAll();
        public List<Post> GetAccepted() => postRepository.GetAccepted();
        public List<Post> GetOnHold() => postRepository.GetOnHold();

        public bool AddLike(Guid id)
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

            return postRepository.Update(post!);
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

        public void ChangeState(Post post, PostState newState)
        {
            post.State = newState;
            newState.SetContext(this);
        }

        public Post? GetPostByOffer(Guid offerId)
        {
            var allPosts = postRepository.GetAll();

            var postWithOffer = allPosts
                .FirstOrDefault(post => post.Offers.Any(offer => offer.Id == offerId));

            return postWithOffer;
        }
    }
}
