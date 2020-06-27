using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AirMonitor.ViewModels
{
    class DetailsViewModel : INotifyPropertyChanged
    {

        private int result = 10;
        public int Result
        {
            get
            {
                return result;
            }
            set
            {
                if (result != value)
                {
                    result = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                }
            }
        }

        private int pressure = 1026;
        public int Pressure
        {
            get
            {
                return pressure;
            }
            set
            {
                if (pressure != value)
                {
                    pressure = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Pressure"));

                }
            }
        }
        
        private int humidity = 90;
        public int Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                if (humidity != value)
                {
                    humidity = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Humidity"));

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
