using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AirMonitor.Models;
using AirMonitor.Services;
using AirMonitor.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AirMonitor.ViewModels
{
    public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public bool IsLoading { get; private set; } = true;

        public bool IsRefreshing { get; private set; } = false;

        public List<Measurement> Measurements { get; private set; }
        public List<string> Locations { get; set; }
        public ICommand RefreshMeasurementsCommand { get; set; }

        private readonly INavigation _navigation;

        public HomeViewModel(INavigation navigation)
        {
            _navigation = navigation;

            RefreshMeasurementsCommand = new RelayCommand(async () => await RefreshData());
        }

        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<Measurement>(OnGoToDetails));

        public void OnGoToDetails(Measurement measurement)
        {
            _navigation.PushAsync(new DetailsPage(measurement));
        }

        private async Task RefreshData()
        {
            IsRefreshing = true;

            var meas = await prepareMeasurements();
            foreach(Measurement measurement in meas)
            {
                Measurements.Add(measurement);
            }
            IsRefreshing = false;
        }

        private async Task<IEnumerable<Measurement>> prepareMeasurements()
        {
            var location = await getGeolocation();
            var stations = await GetStations(location);
            Locations = new List<string>();

            var measurements = await GetMeasurements(stations);
            return measurements;
        }


        private async Task<IEnumerable<Measurement>> GetMeasurements(IEnumerable<Station> stations)
        {
            var measurements = new List<Measurement>();
            AirlyService airlyService = new AirlyService();
            Measurements = new List<Measurement>();
            foreach (var station in stations)
            {
                var measurement = await airlyService.GetMeasurements(station.Id);

                measurements.Add(measurement);
            }

            return measurements;
        }

        private async Task<IEnumerable<Station>> GetStations(Location location)
        {
            var airlyService = new AirlyService();
            return await airlyService.GetNearestStation(location);
        }

        private async Task<Location> getGeolocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
           
            return location;
         
        }
        
        
    }
}
