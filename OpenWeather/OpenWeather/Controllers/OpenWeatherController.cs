using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenWeather.Models;
using OpenWeather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OpenWeather.Controllers
{
        public class OpenWeatherController : Controller
        {
            private readonly IOpenWeatherRepository _openWeatherRepository;

            // Dependency Injection
            public OpenWeatherController(IOpenWeatherRepository openWeatherRepository)
            {
            _openWeatherRepository = openWeatherRepository;
            }
        // GET: Models/SearchCity
        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        // POST: Models/SearchCity
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeather", new { city = model.CityName });
            }
            return View(model);
        }

        // GET: Models/City
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _openWeatherRepository.GetForecast(city);
            City viewModel = new City();
            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }

            return View(viewModel);
        }
    }
}
