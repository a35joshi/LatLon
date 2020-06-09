using System.Collections.Generic;

namespace JokeCompany.JokeGenerator.Application
{
    // Decorated class
    // Since the output of the joke API is a JSON, JokeFeed class inherits from the JSON API base class.
    public class JokeFeed : ApiJsonFeed
    {
        private readonly static string decoratedUrl = ApplicationConstants.RANDOM_JOKES_API_URL;
        public JokeFeed() : base(decoratedUrl)
        {

        }

        public List<string> GetCategories()
        {
            return RetrieveDeserializedResponseFromUrl<List<string>>(ApplicationConstants.CATEGORIES_API_ENDPOINT);
        }

        public string GetJoke(string category)
        {            
            return RetrieveDeserializedResponseFromUrl<Joke>(string.IsNullOrWhiteSpace(category) ? 
                ApplicationConstants.RANDOM_JOKES_API_ENDPOINT :
                ApplicationConstants.RANDOM_JOKES_API_CATEGORY_ENDPOINT.Replace(ApplicationConstants.CATEGORY, category))
                .Value;
        }
    }    
}