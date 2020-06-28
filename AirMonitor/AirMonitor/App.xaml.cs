using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AirMonitor.Services;
using AirMonitor.Views;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirMonitor
{
    public partial class App : Application
    {
        public static string ApiKey { get; private set; }
        public static string ApiUrl { get; private set; }
        public static string ApiNearest { get; private set; }
        public static string ApiMeasurements { get; private set; }



        public App()
        {
            InitializeComponent();
            prepareApp();
           
            
            MainPage = new RootTabbedPage();

        }

        private async Task prepareApp()
        {
            await loadConfiguration();
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

        private async Task loadConfiguration()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(App));
            string[] resourceNames = assembly.GetManifestResourceNames();
            string configName = resourceNames.FirstOrDefault(s => s.Contains("config.json"));

            using (Stream stream = assembly.GetManifestResourceStream(configName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = await reader.ReadToEndAsync();
                    JObject dynamicJson = JObject.Parse(json);

                    ApiKey = dynamicJson["ApiKey"].Value<string>();
                    ApiUrl = dynamicJson["ApiUrl"].Value<string>();
                    ApiNearest = dynamicJson["ApiNearest"].Value<string>();
                    ApiMeasurements = dynamicJson["ApiMeasurements"].Value<string>();
                }
            }
        }
    }
}
