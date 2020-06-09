using Newtonsoft.Json;

namespace JokeCompany.JokeGenerator.Application
{
    class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
}
