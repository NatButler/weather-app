using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class ResponseBody
{
    [JsonPropertyName("location")]
    public Location? Location { get; set; }
    [JsonPropertyName("current")]
    public Current? Current { get; set; }
    [JsonPropertyName("forecast")]
    public Forecast? Forecast { get; set; }
}

public partial class Location
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

public partial class Current
{
    [JsonPropertyName("temp_c")]
    public decimal Temp_c { get; set; }
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
}

public partial class Forecast
{
    [JsonPropertyName("forecastday")]
    public IList<ForecastDay>? ForecastDay { get; set; }
}

public partial class ForecastDay
{
    [JsonPropertyName("day")]
    public Day? Day { get; set; }
    [JsonPropertyName("astro")]
    public Astro? Astro { get; set; }
}

public partial class Day
{
    [JsonPropertyName("maxtemp_c")]
    public decimal Maxtemp_c { get; set; }
    [JsonPropertyName("mintemp_c")]
    public decimal Mintemp_c { get; set; }
}

public partial class Astro
{
    [JsonPropertyName("sunrise")]
    public string? Sunrise { get; set; }
    [JsonPropertyName("sunset")]
    public string? Sunset { get; set; }
}
