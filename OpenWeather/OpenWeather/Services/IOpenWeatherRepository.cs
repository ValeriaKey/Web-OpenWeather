using OpenWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeather.Services
{
    public interface IOpenWeatherRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
