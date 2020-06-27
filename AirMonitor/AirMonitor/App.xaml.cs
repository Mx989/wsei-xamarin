using System;
using AirMonitor.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace AirMonitor
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(prepareTabbedPage()); // new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private Xamarin.Forms.TabbedPage prepareTabbedPage()
        {
            var page = new Xamarin.Forms.TabbedPage();
            page.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            page.Title = "Main Tabbed Page";
            page.Children.Add(new HomePage
            {
                Title = "Home"
            });
            page.Children.Add(new SettingsPage
            {
                Title = "Settings"
            });
            return page;
        }
    }
}
