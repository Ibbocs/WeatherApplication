using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApplication.Constants;
using WeatherApplication.Models;

namespace WeatherApplication.ViewModels
{
    public partial class WeatherViewModel : ObservableObject
    //view model oldugundan, xaml terefinde deyisikleri gormesi ucun Mvvm patterini qururuq ve ObservableObject-microsoftun verdiyi mauiToolKit nugetinden gelir ve bu clasin bir ViewModel oldugunu bildirir ki, properti ve Commandleri biz deyil oftamatik ozu hazirlasin, eks halda ozumuz elle etmeli olacaqdiq bunun elediyi isleri...
    //qeyd: bu class partial olmaq mecburiyyetindedir
    {

        public WeatherViewModel()
        {
            GetWeather();
        }

        [ObservableProperty] //bunun sayesinde bize bu fieldin propertisin generate edecek ve onun davranislari ile bir yerde(full-prop mentiqi ile), biz de bu propertiyi View hissesinde bindigde isledeceyik...
        private RootModel _rootModel;

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        private bool isLoading; //loading ekrani ucun

        public DateTime Date { get; set; } = DateTime.Now;



        public async void GetWeather()//app ilk run verilende ise dusecek methodumuz(daha dogrusu viewmodel instancesi alinanda
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();//locatin melumatin almaq ucun, default her ehtimala yaziriq, bos gelmesin. Ve androidde location oxumaq ucun: Platforms-Android-AndroidManifest girib Acces_BackGround_Location, Access_Coares_Location ve Access_Fine_Location aciriq

            if (location != null)
            {
                await GetWeather(location, ("az", "10"));//todo configurationdan oxumaga calis bunu, ya da hardcode olmagdan bir cure cixart(View da oxumaq olar meselen)
            }

            //Geolocator geoLocator = new Geolocator();
            //GeolocationAccessStatus accessStatus = await Geolocator.RequestAccessAsync();
            //if (accessStatus == GeolocationAccessStatus.Allowed)
            //{
            //    // Put all your Code here to access location services
            //    Geoposition geoposition = await geoLocator.GetGeopositionAsync();
            //    var position = geoposition.Coordinate.Point.Position;
            //    var latlong = string.Format("lat:{0}, long:{1}", position.Latitude, position.Longitude);
            //}
            //else if (accessStatus == GeolocationAccessStatus.Denied)
            //{
            //    // No Accesss
            //}
            //else
            //{
            //}
        }

        private async Task GetWeather(Location location, (string lang, string day) UrlSettings)
        {
            try
            {
                IsLoading = true; //Bu loading ekranin getirecek

                using HttpClient client = new HttpClient();

                //client.BaseAddress = new Uri(UrlConstan.GetMyUrl(location, UrlSettings));
                //client.BaseAddress = new Uri(UrlConstan.BaseUrl);

                HttpResponseMessage response = await client.GetAsync(UrlConstan.GetMyUrl(location, UrlSettings));
                var resultModel = await response.Content.ReadFromJsonAsync<RootModel>();

                if (resultModel != null)
                {
                    RootModel = resultModel; //bular ObservableProperty bunun arxada oftamatik generate elediyi propertilerdi...
                    IsVisible = true;
                }
                IsLoading = false; ////Bu loading ekranin aparir

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ICommand SearchCommand =>
     new Command(async (searchText) =>
     {
         var location = await GetCoordinatesAsync(searchText.ToString());
         await GetWeather(location, ("az", "10"));
     }); //viewda olan search bari isledilende isleyecek methodumuz

        private async Task<Location> GetCoordinatesAsync(string value)
        {
            var locations = await Geocoding.Default.GetLocationsAsync(value);
            var location = locations?.FirstOrDefault();

            return location;
        }


    }
}
