using System.Collections.Generic;

namespace JokeCompany.JokeGenerator.Application
{
    public class JokeHelper
    {
        private readonly RandomNameFeed randomNameFeed;
        private readonly JokeFeed jokeJsonFeed;

        public JokeHelper()
        {
            randomNameFeed = new RandomNameFeed();
            jokeJsonFeed = new JokeFeed();
        }

        public List<string> GetCategories()
        {
            return jokeJsonFeed.GetCategories();
        }

        public List<string> GetJokes(string category, int numberOfJokes, bool isRandomNameRequired)
        {
            List<string> jokes = new List<string>();

            for (int i = 0; i < numberOfJokes; i++)
            {
                string joke = jokeJsonFeed.GetJoke(category);                
                jokes.Add(isRandomNameRequired ? joke.Replace(ApplicationConstants.CHUCK_NORRIS, randomNameFeed.GetRandomName()) : joke);
            }
            return jokes;
        }
    }
}
