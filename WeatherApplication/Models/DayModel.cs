namespace WeatherApplication.Models;

public class DayModel
{
    public double maxtemp_c { get; set; }
    public double mintemp_c { get; set; }
    public double avgtemp_c { get; set; }
    public double maxwind_kph { get; set; }
    public double avgvis_km { get; set; }
    public ConditionModel condition { get; set; }
}
