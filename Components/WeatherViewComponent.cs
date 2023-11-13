using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AspNetMVC.Models;

namespace AspNetMVC.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string region)
        {

            using (var httpClient = new HttpClient())
            {
                var apiKey = "4c99d519b9400d1840bbe245be627bb7";
                var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={region}&appid={apiKey}&units=metric";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic jsonObject = JsonConvert.DeserializeObject(content);

                    WeatherModel weather = new WeatherModel
                    {
                        City = jsonObject.name,
                        Temperature = jsonObject.main.temp,
                        Weather = jsonObject.weather[0].main,
                        WeatherDescription = jsonObject.weather[0].description,
                        Humidity = jsonObject.main.humidity,
                        WindSpeed = jsonObject.wind.speed,


                    };
                    return View("/Views/ProductWeather/Weather.cshtml", weather);
                }
            }

            return Content("Помилка отримання погоди");
        }

    }
}