using Newtonsoft.Json;

namespace JokeCompany.JokeGenerator.Application
{
    public class Joke
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}