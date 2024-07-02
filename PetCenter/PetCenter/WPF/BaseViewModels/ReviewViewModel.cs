using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class ReviewViewModel(Review review) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public int Grade
        {
            get => _grade;
            set => SetField(ref _grade, value);
        }

        public string Comment
        {
            get => _comment;
            set => SetField(ref _comment, value);
        }

        private Guid _id = review.Id;
        private int _grade = review.Grade;
        private string _comment = review.Comment;
    }
}
