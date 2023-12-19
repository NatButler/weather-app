using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _client;

    public HomeController(HttpClient client)
    {
        _client = client;
    }

    public async Task<ActionResult> Index(string location)
    {
        if (location == null)
        {
            return View();
        }

        HttpResponseMessage response = await _client.GetAsync($"http://api.weatherapi.com/v1/forecast.json?key=97dbd1e23dd747608f4124045231512&q={location}&days=1&aqi=no&alerts=no");
        string responseBody = response.Content.ReadAsStringAsync().Result;

        if (response.IsSuccessStatusCode)
        {
            var responseBodyDeserialized = JsonSerializer.Deserialize<ResponseBody>(responseBody);
            ViewData["Location"] = $"{responseBodyDeserialized?.Location?.Name}, {responseBodyDeserialized?.Location?.Country}";
            ViewData["CurrentTemp"] = responseBodyDeserialized?.Current?.Temp_c.ToString();
            ViewData["MinTemp"] = responseBodyDeserialized?.Forecast?.ForecastDay?[0].Day?.Mintemp_c.ToString();
            ViewData["MaxTemp"] = responseBodyDeserialized?.Forecast?.ForecastDay?[0].Day?.Maxtemp_c.ToString();
            ViewData["Humidity"] = responseBodyDeserialized?.Current?.Humidity.ToString();
            ViewData["Sunrise"] = responseBodyDeserialized?.Forecast?.ForecastDay?[0].Astro?.Sunrise;
            ViewData["Sunset"] = responseBodyDeserialized?.Forecast?.ForecastDay?[0].Astro?.Sunset;
        }
        else
        {
            var responseErrorDeserialized = JsonSerializer.Deserialize<ResponseError>(responseBody);
            ViewData["Error"] = responseErrorDeserialized?.Error?.Message;
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
