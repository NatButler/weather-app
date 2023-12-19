using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class ResponseError
{
    [JsonPropertyName("error")]
    public Error? Error { get; set; }
}

public partial class Error
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}