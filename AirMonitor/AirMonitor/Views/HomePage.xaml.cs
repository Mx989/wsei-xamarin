using System;
using System.Collections.Generic;
using AirMonitor.Models;
using AirMonitor.ViewModels;
using Xamarin.Forms;

namespace AirMonitor.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel(Navigation);
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as HomeViewModel).OnGoToDetails((Measurement)e.Item);
        }

    }
}
