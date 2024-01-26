namespace WeatherApplication.Models;

public class CurrentModel
{
    public int last_updated_epoch { get; set; }
    public string last_updated { get; set; }
    public double temp_c { get; set; }
    public int is_day { get; set; }
    public ConditionModel condition { get; set; }
    public double wind_kph { get; set; }
    public string wind_dir { get; set; }
    public int cloud { get; set; }
    public double feelslike_c { get; set; }
    public double vis_km { get; set; }
    public double gust_kph { get; set; }
}
