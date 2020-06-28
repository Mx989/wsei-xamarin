using AirMonitor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AirMonitor.ViewModels
{
    public class DetailsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        

        public DetailsViewModel()
        {
        }





        private int _caqiValue = 57;
        public int CaqiValue
        {
            get => _caqiValue;
            set => SetProperty(ref _caqiValue, value);
            /* SetProperty is a helper function to shorten our code. This is equivalent of:
             * set
             * {
             *  if (_caqiValue == value) return; // Don't reassign value and notify view if value didn't change
             *
             *  _caqiValue = value;
             *  RaisePropertyChanged();
             * }
             */
        }

        private string _caqiTitle = "Świetna jakość!";
        public string CaqiTitle
        {
            get => _caqiTitle;
            set => SetProperty(ref _caqiTitle, value);
        }

        private string _caqiDescription = "Możesz bezpiecznie wyjść z domu bez swojej maski anty-smogowej i nie bać się o swoje zdrowie.";
        public string CaqiDescription
        {
            get => _caqiDescription;
            set => SetProperty(ref _caqiDescription, value);
        }

        private int _pm25Value = 34;
        public int Pm25Value
        {
            get => _pm25Value;
            set => SetProperty(ref _pm25Value, value);
        }

        private int _pm25Percent = 137;
        public int Pm25Percent
        {
            get => _pm25Percent;
            set => SetProperty(ref _pm25Percent, value);
        }

        private int _pm10Value = 67;
        public int Pm10Value
        {
            get => _pm10Value;
            set => SetProperty(ref _pm10Value, value);
        }

        private int _pm10Percent = 135;
        public int Pm10Percent
        {
            get => _pm10Percent;
            set => SetProperty(ref _pm10Percent, value);
        }

        private double _humidityValue = 0.95;
        public double HumidityValue
        {
            get => _humidityValue;
            set => SetProperty(ref _humidityValue, value);
        }

        private int _pressureValue = 1027;
        public int PressureValue
        {
            get => _pressureValue;
            set => SetProperty(ref _pressureValue, value);
        }

        public Measurement Measurement { set { AssignMeasurement(value); } }

        public void AssignMeasurement(Measurement measurement)
        {
            MeasurementItem current = measurement.Current;
            AirQualityIndex index = current.Indexes.FirstOrDefault(c => c.Name == "AIRLY_CAQI");
            MeasurementValue[] values = current.Values;
            AirQualityStandard[] standards = current.Standards;

            Pm10Value = GetPM("PM10", current).Value;
            Pm25Value = GetPM("PM25", current).Value;
            Pm10Percent = GetPM("PM10", current).Percentage;
            Pm25Percent = GetPM("PM25", current).Percentage;

            CaqiValue = Convert.ToInt32(Math.Round(double.Parse(index.Value)));
            CaqiTitle = index.Description;
            CaqiDescription = index.Advice;

            HumidityValue = Convert.ToInt32(Math.Round(double.Parse(values.FirstOrDefault(value => value.Name == "HUMIDITY").Value)));
            PressureValue = Convert.ToInt32(Math.Round(double.Parse(values.FirstOrDefault(value => value.Name == "PRESSURE").Value)));
        }

        private PM GetPM(string name, MeasurementItem current)
        {
            int value = int.Parse(current.Values.FirstOrDefault(val => val.Name == name).Value);
            int percentage = (int)Math.Round(current.Standards.FirstOrDefault(standard => standard.Pollutant == name).Percent);
            return new PM(value, percentage);
        }

    }
}
