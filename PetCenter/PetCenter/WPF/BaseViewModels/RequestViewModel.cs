using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class RequestViewModel(Request request, string username) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public Person Author
        {
            get => _author;
            set => SetField(ref _author, value);
        }

        public DateOnly CreationDate
        {
            get => _creationDate;
            set => SetField(ref _creationDate, value);
        }

        public int VotesFor
        {
            get => _votesFor;
            set => SetField(ref _votesFor, value);
        }

        public int VotesAgainst
        {
            get => _votesAgainst;
            set => SetField(ref _votesAgainst, value);
        }

        public string AuthorUsername
        {
            get => _authorUsername;
            set => SetField(ref _authorUsername, value);
        }

        private Guid _id = request.Id;
        private Person _author = request.Author;
        private DateOnly _creationDate = request.CreationDate;
        private int _votesFor = request.VotesFor;
        private int _votesAgainst = request.VotesAgainst;
        private string _authorUsername = username;
    }
}
