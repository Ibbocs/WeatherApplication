namespace WeatherApplication.Models;

public class RootModel
{
    public LocationModel location { get; set; }
    public CurrentModel current { get; set; }
    public ForecastModel forecast { get; set; }
}