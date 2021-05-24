using System.Text.Json.Serialization;

namespace Kalibrate.Chuck.Norris.Models
{
    public class Joke
    {
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("icon_url")]
        public string? IconUrl { get; set; }
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}