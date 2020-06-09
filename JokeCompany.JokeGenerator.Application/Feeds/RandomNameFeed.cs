namespace JokeCompany.JokeGenerator.Application
{
    // Decorated class
    public class RandomNameFeed : ApiJsonFeed
    {
        private readonly static string decoratedUrl = ApplicationConstants.RANDOM_NAME_API_URL;
        public RandomNameFeed() : base(decoratedUrl)
        {

        }

        public string GetRandomName()
        {
            Person randomPerson = RetrieveDeserializedResponseFromUrl<Person>(decoratedUrl);
            return $"{randomPerson.Name} {randomPerson.Surname}, a {randomPerson.Gender} from {randomPerson.Region},";
        }
    }
}