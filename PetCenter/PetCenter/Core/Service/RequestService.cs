using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Stores;
using PetCenter.Domain;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Domain.State;
using PetCenter.WPF.BaseViewModels;

namespace PetCenter.Core.Service
{
    public class RequestService(IRequestRepository requestRepository, AuthenticationStore authenticationStore, NotificationService notificationService, IAccountRepository accountRepository)
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

        public bool HasVoted(Guid id)
        {
            var user = authenticationStore.LoggedUser;
            if (user == null) return true;
            var request = GetById(id);
            if (request == null) return true;
            return request.Voters.Any(v => v.Id == user.Id);
        }

        public bool HasEnded(Guid id)
        {
            var request = GetById(id);
            if (request == null) return false;
            return DateTime.Now > request.CreationDate.ToDateTime(TimeOnly.MinValue).Add(Constants.VotingPeriod);
        }

        public bool ConcludeRequest(Guid id)
        {
            var request = GetById(id);
            if (request == null) return false;
            if (request.ResultPositive)
            {
                string message = $"Congratulations, you have been promoted to a volunteer! Welcome to our team! Feel free to contact {Constants.ContactNumber} for guidance.";
                notificationService.SendNotification(request.Author, message);
                request.Author.Account.Type = AccountType.Volunteer;
                accountRepository.Update(request.Author.Account);
                Delete(request);
                return true;
            }
            else
            {
                string message = $"It has been decided that you are not yet ready to join our team. Feel free to apply again in the future.";
                notificationService.SendNotification(request.Author, message);
                Delete(request);
                return false;
            }
        }
    }
}
