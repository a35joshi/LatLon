using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeCompany.JokeGenerator.Application
{
    // Decorator base class
    public class ApiJsonFeed
    {
        // This can be one of many possibilities such as the random name Url, the jokes url etc.
        private readonly string decoratorUrl;
        public ApiJsonFeed(string baseUrl)
        {
            decoratorUrl = baseUrl;
        }

        // Since this is the base class, all the inherited classes can use this method with an access level of protected
        // i.e, no need to make it public.
        protected T RetrieveDeserializedResponseFromUrl<T>(string url)
        {                        
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(decoratorUrl)
                };

                Task<string> result = Task.FromResult(client.GetStringAsync(url).Result);

                if (result.IsCompletedSuccessfully)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(result.Result);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error while deserializing object: {ex.Message}");
                    }
                }
                else
                {

                    throw new Exception("Couldn't retrieve result from the API URL");
                }
            }
            catch (Exception ex)
            {                
                throw new Exception($"Error in getting response: {ex.Message}");
            }          
        }
    }
}
