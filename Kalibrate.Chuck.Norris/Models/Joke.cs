using System.Text.Json.Serialization;

namespace Kalibrate.Chuck.Norris.Models
{
    public class Joke
    {
        public string? Category { get; set; }

        [JsonPropertyName("icon_url")]
        public string? IconUrl { get; set; }

        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? Value { get; set; }
    }
}