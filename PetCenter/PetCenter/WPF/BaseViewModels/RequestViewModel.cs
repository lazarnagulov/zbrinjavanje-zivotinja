using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class RequestViewModel(Request request) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public Person Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        public DateOnly CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }

        public int VotesFor
        {
            get => _votesFor;
            set
            {
                _votesFor = value;
                OnPropertyChanged();
            }
        }

        public int VotesAgainst
        {
            get => _votesAgainst;
            set
            {
                _votesAgainst = value;
                OnPropertyChanged();
            }
        }

        private Guid _id = request.Id;
        private Person _author = request.Author;
        private DateOnly _creationDate = request.CreationDate;
        private int _votesFor = request.VotesFor;
        private int _votesAgainst = request.VotesAgainst;
    }
}
