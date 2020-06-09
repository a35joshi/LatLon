using JokeCompany.JokeGenerator.Application;
using NUnit.Framework;
using System.Collections.Generic;

namespace JokeCompany.JokeGenerator.ApplicationTests
{
    public class JokeFeedTest
    {
        [Test]
        public void GetCategories_Count_Correct()
        {
            // Setup
            JokeFeed jokeFeed = new JokeFeed();
            List<string> categories;

            // Exercise
            categories = jokeFeed.GetCategories();

            // Verify
            Assert.AreEqual(16, categories.Count);
        }

        [Test]
        public void GetJoke_Category_Present()
        {
            // Setup
            JokeFeed jokeFeed = new JokeFeed();
            string joke;

            // Exercise
            joke = jokeFeed.GetJoke("travel");

            // Verify
            Assert.IsNotNull(joke);
        }

       [Test]
       public void GetJoke_Category_Missing()
        {
            // Setup
            JokeFeed jokeFeed = new JokeFeed();
            string joke;

            // Exercise
            joke = jokeFeed.GetJoke(null);

            // Verify
            Assert.IsNotNull(joke);
        }
    }
}