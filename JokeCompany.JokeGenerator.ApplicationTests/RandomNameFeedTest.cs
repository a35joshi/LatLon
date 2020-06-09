using JokeCompany.JokeGenerator.Application;
using NUnit.Framework;

namespace JokeCompany.JokeGenerator.ApplicationTests
{
    public class RandomNameFeedTest
    {
        [Test]
        public void GetRandomName_Present()
        {
            // Setup
            RandomNameFeed randomNameFeed = new RandomNameFeed();

            // Exercise
            string name = randomNameFeed.GetRandomName();

            // Verify
            Assert.IsNotNull(name);
        }
    }
}
