namespace JokeCompany.JokeGenerator.Application
{
    // Generic class that stores all constants used in this application
    class ApplicationConstants
    {
        public const string CHUCK_NORRIS = "Chuck Norris";
        public const string RANDOM_NAME_API_URL = "https://names.privserv.com/api/";
        public const string RANDOM_JOKES_API_URL = "https://api.chucknorris.io/";
        public const string CATEGORIES_API_ENDPOINT = "jokes/categories";
        public const string RANDOM_JOKES_API_ENDPOINT = "jokes/random";
        public const string INVALID_RESPONSE = "Invalid response. Please try again! \n";
        public const string YES_OR_NO = "y/n";
        public const string CATEGORY = "{category}";
        public const string RANDOM_JOKES_API_CATEGORY_ENDPOINT = "jokes/random?category=" + CATEGORY;

        public const int JOKE_LOWER_RANGE = 0;
        public const int JOKE_UPPER_RANGE = 16;
    }
}
