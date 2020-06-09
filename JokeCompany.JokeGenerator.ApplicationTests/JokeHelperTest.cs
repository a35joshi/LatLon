using JokeCompany.JokeGenerator.Application;
using NUnit.Framework;
using System.Collections.Generic;

namespace JokeCompany.JokeGenerator.ApplicationTests
{
    public class JokeHelperTest
    {
        [Test]
        public void GetJoke_Count_Of_Two()
        {
            // Setup
            JokeHelper jokeHelper = new JokeHelper();
            List<string> jokes;

            // Exercise
            jokes = jokeHelper.GetJokes(null, 2, false);

            // Verify
            Assert.AreEqual(2, jokes.Count);
        }

        [Test]
        public void GetJoke_Travel_Category_Present()
        {
            // Setup
            JokeHelper jokeHelper = new JokeHelper();
            List<string> jokes;

            // Exercise
            jokes = jokeHelper.GetJokes("travel", 1, false);

            // Verify
            Assert.IsNotNull(jokes);
        }

        [Test]
        public void GetJoke_Random_Name_Present()
        {
            // Setup
            JokeHelper jokeHelper = new JokeHelper();
            List<string> jokes;

            // Exercise
            jokes = jokeHelper.GetJokes(null, 1, true);

            // Verify
            Assert.IsNotNull(jokes);
        }

        [Test]
        public void GetJoke_Count_Of_One_Travel_Category_Random_Name_Present()
        {
            // Setup
            JokeHelper jokeHelper = new JokeHelper();
            List<string> jokes;

            // Exercise
            jokes = jokeHelper.GetJokes("travel", 1, true);

            // Verify
            Assert.IsNotNull(jokes);
            Assert.AreEqual(1, jokes.Count);
        }
    }
}
