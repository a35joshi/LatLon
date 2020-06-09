using System;
using System.Collections.Generic;

namespace JokeCompany.JokeGenerator.Application
{
    class JokeGenerator
    {        
        static JokeHelper jokeHelper;
        static ConsoleHelper consoleHelper;
        static List<string> cachedCategories = new List<string>();

        static void Main()
        {
            consoleHelper = new ConsoleHelper();
            jokeHelper = new JokeHelper();

            Welcome();            
            GetJokes();            
            End();
        }

        private static void Welcome()
        {
            consoleHelper.WriteLine("Welcome to the Joke Company's Joke Generator, where leaving is not an option.\n");
        }

        private static void GetJokes()
        {
            bool getJokes = true;

            while (getJokes)
            {
                try
                {
                    bool isCategoryRequired = consoleHelper.GetBooleanResponse("Do you want a joke from a specific category?");
                    // Cache categories as they rarely ever change.
                    string category = null;
                    if(isCategoryRequired) 
                    {
                        if (cachedCategories.Count == 0)
                        {
                            cachedCategories = jokeHelper.GetCategories();
                        }                        
                        category = consoleHelper.GetListResponse(cachedCategories);
                    }

                    
                    int numberOfJokes = consoleHelper.GetIntResponse("How many jokes would you like? (1-15)");
                    
                    bool isRandomNameRequired = consoleHelper.GetBooleanResponse("Do you want random names substituted instead?");
                    
                    List<string> jokes = jokeHelper.GetJokes(category, numberOfJokes, isRandomNameRequired);

                    consoleHelper.ClearConsole();
                    consoleHelper.OutputResults(jokes);                    
                    
                    getJokes = consoleHelper.GetBooleanResponse("Do you want more of these jokes?");
                    consoleHelper.ClearConsole();
                }
                catch (Exception ex)
                {
                    consoleHelper.WriteLine($"Sorry, your task has failed successfully(pun intended) due to: {ex.Message}" +
                        $"If this error persists, please contact the JokeCompany Hotline for more information. \n");
                }
            }
        }
        private static void End()
        {
            consoleHelper.WriteLine("Thank you for using the Joke Generator. Goodbyes suck :( \n");
        }
    }
}