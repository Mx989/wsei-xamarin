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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void NavigateToDetails(object sender, EventArgs e)
        {
            var page = new DetailsPage();
            await Navigation.PushAsync(page);
        }        
        
        private async void NavigateToSettings(object sender, EventArgs e)
        {
            var page = new SettingsPage();
            await Navigation.PushAsync(page);
        }
    }
}