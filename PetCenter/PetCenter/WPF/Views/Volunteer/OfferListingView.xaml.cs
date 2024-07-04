using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for OfferListingView.xaml
    /// </summary>
    public partial class OfferListingView : UserControl
    {
        public OfferListingView()
        {
            InitializeComponent();
            this.DataContextChanged += (a,b)=>{ Trace.WriteLine(a); Trace.WriteLine(b.NewValue); Trace.WriteLine(b.OldValue); };
        }
    }
}
