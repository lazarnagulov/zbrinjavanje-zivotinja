using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class CommentViewModel(Comment comment) : ViewModelBase
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

        public string Text
        {
            get => _text;
            set => SetField(ref _text, value);
        }

        private Guid _id = comment.Id;
        private Person _author = comment.Author;
        private string _text = comment.Text;
    }
}
