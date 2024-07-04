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
    public class RequestService(IRequestRepository requestRepository, AuthenticationStore authenticationStore)
    {
        public bool Insert(Request request) => requestRepository.Insert(request);
        public bool Delete(Request request) => requestRepository.Delete(request);
        public Request? GetById(Guid id) => requestRepository.GetById(id);
        public bool Update(Request request) => requestRepository.Update(request);

        public List<Request> GetAll() => requestRepository.GetAll();
        public List<Request> GetAllIncluded() => requestRepository.GetAllIncluded();

        public void AddVote(Guid id, bool against)
        {
            var request = GetById(id);
            var user = authenticationStore.LoggedUser;
            Trace.Assert(request is not null);
            Trace.Assert(user is not null);
            request.AddVoter(user);
            if (against)
                request.VotesAgainst++;
            else
                request.VotesFor++;
            requestRepository.Update(request!);
        }

        public void DeleteForCurrentUser()
        {
            var user = authenticationStore.LoggedUser;
            if (user == null)
                return;
            Request request = requestRepository.GetAllIncluded().First(r => r.Author.Id == user.Id);
            requestRepository.Delete(request);
        }

        public bool CreateRequest()
        {
            var user = authenticationStore.LoggedUser;
            if (user == null)
                return false;
            return Insert(new Request(user));
        }


        public List<Request> GetNotVoted()
        {
            var user = authenticationStore.LoggedUser;
            if (user == null)
                return new();
            return requestRepository.GetAllIncluded().Where(r => !r.Voters.Any(v => v.Id == user.Id)).ToList();
        }

        public bool HasRequest()
        {
            var user = authenticationStore.LoggedUser;
            if (user == null)
                return true;
            return GetAllIncluded().Any(r => r.Author.Id == user.Id);
        }
    }
}
