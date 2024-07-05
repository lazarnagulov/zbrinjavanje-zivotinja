﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetCenter.WPF.Views.Administrator
{
    /// <summary>
    /// Interaction logic for AddFirstVolunteerView.xaml
    /// </summary>
    public partial class AddVolunteerView : UserControl
    {
        public AddVolunteerView()
        {
            InitializeComponent();

            BirthDate.DisplayDateStart = new DateTime(1924, 1, 1);
            BirthDate.DisplayDateEnd = DateTime.Today.AddYears(-16);   //minimum age of 16
            BirthDate.SelectedDate = DateTime.Today.AddYears(-16);
        }
    }
}
