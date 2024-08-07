﻿using PetCenter.WPF.ViewModels.Member;
using PetCenter.WPF.ViewModels.Volunteer;
using System;
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
using System.Windows.Shapes;

namespace PetCenter.WPF.Views.Volunteer
{
    /// <summary>
    /// Interaction logic for VolunteerWindow.xaml
    /// </summary>
    public partial class VolunteerWindow : Window
    {
        public VolunteerWindow(VolunteerViewModel viewModel)// : base(viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
