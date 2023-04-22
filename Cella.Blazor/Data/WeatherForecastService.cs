using System.Collections;

namespace Cella.Blazor.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync()
    {
        List<WeatherForecast> weatherForecastList = new List<WeatherForecast>();

        WeatherForecast weatherForecast = new WeatherForecast();
        weatherForecast.TemperatureC = 20;
        weatherForecast.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
        weatherForecast.Date = DateTime.Now.Date;
        weatherForecastList.Add(weatherForecast);
        
        WeatherForecast weatherForecast2 = new WeatherForecast();
        weatherForecast2.TemperatureC = 10;
        weatherForecast2.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
        weatherForecast2.Date = DateTime.Now.Date;
        weatherForecastList.Add(weatherForecast2);
        
        WeatherForecast weatherForecast3 = new WeatherForecast();
        weatherForecast3.TemperatureC = 56;
        weatherForecast3.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
        weatherForecast3.Date = DateTime.Now.Date;
        weatherForecastList.Add(weatherForecast3);
        return weatherForecastList.AsEnumerable();


    }
}