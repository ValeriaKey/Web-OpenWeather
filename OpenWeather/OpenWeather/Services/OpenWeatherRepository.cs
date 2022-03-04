﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using OpenWeather.Models;
using OpenWeather.Config;

namespace OpenWeather.Services
{
        public class OpenWeatherRepository : IOpenWeatherRepository
        {
            WeatherResponse IOpenWeatherRepository.GetForecast(string city)
            {
            string IDOWeather = Constants.OPEN_WEATHER_APPID;
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={IDOWeather}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                {
                    // Deserialize the string content into JToken object
                    var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                    // Deserialize the JToken object into our WeatherResponse Class
                    return content.ToObject<WeatherResponse>();
                }

                return null;
            }
        }
}
