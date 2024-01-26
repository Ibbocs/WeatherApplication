using WeatherApplication.ViewModels;

namespace WeatherApplication
{
    public partial class MainPage : ContentPage //bizim ana pageimz
    {
        public MainPage(WeatherViewModel weatherViewModel) //Dep-inject ile View hissemize ViewModelin veririk.(qeyd: MauiProgram.cs IOc elave edilmelidi bular!!!
        {
            InitializeComponent();
            BindingContext = weatherViewModel; //binding elemek ucun
        }
    }

}
