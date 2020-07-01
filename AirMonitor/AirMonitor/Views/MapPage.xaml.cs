using AirMonitor.Models;
using AirMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private HomeViewModel _viewModel => BindingContext as HomeViewModel;
        public MapPage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel(Navigation);
        }

        void InfoWindow_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var x = (sender as Xamarin.Forms.Maps.Pin);
            _viewModel.InfoWindowClickedCommand.Execute(x);
        }
    }
}