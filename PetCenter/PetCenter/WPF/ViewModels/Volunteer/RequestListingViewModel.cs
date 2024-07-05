using PetCenter.Core.Service;
using PetCenter.Domain.Model;
using PetCenter.Repository;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.State;
using System.Windows;
using Microsoft.Extensions.Hosting;
using System.Windows.Navigation;

namespace PetCenter.WPF.ViewModels.Volunteer
{
    public class RequestListingViewModel : ViewModelBase
    {
        private readonly RequestService _requestService;
        private readonly NotificationService _notificationService;

        private ObservableCollection<RequestViewModel> _requests = new();
        public ObservableCollection<RequestViewModel> Requests
        {
            get => _requests;
            set => SetField(ref _requests, value);
        }
        public ICommand VoteForCommand { get; }
        public ICommand VoteAgainstCommand { get; }
        public ICommand ConcludeVotingCommand { get; }

        public RequestListingViewModel(RequestService requestService, NotificationService notificationService)
        {
            _requestService = requestService;
            _notificationService = notificationService;
            LoadRequests();

            VoteForCommand = new RelayCommand<RequestViewModel>(r => Vote(r, false), CanVote);
            VoteAgainstCommand = new RelayCommand<RequestViewModel>(r => Vote(r, true), CanVote);
            ConcludeVotingCommand = new RelayCommand<RequestViewModel>(ConcludeVoting, CanConclude);
        }

        private void LoadRequests()
        {
            Requests = new ObservableCollection<RequestViewModel>();
            foreach (var request in _requestService.GetAllIncluded())
            {
                Requests.Add(new RequestViewModel(request, request.Author.Account.Username));
            }
        }
            
        private void Vote(RequestViewModel? request, bool against)
        {
            if (request == null)
            {
                MessageBox.Show("An error occurred.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _requestService.AddVote(request.Id, against);
            LoadRequests();
            OnPropertyChanged(nameof(Requests));
        }

        private bool CanVote(RequestViewModel? request) => request != null && !_requestService.HasVoted(request.Id) && !_requestService.HasEnded(request.Id);

        private void ConcludeVoting(RequestViewModel? request)
        {
            if (request == null)
            {
                MessageBox.Show("An error occurred.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool added = _requestService.ConcludeRequest(request.Id);
            if (added)
                MessageBox.Show($"{request.Author} has been added to volunteers!", "Voting concluded", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"{request.Author} has not been added to volunteers.", "Voting concluded", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadRequests();
            OnPropertyChanged(nameof(Requests));
        }

        private bool CanConclude(RequestViewModel? request) => request != null && _requestService.HasEnded(request.Id); 
    }
}
