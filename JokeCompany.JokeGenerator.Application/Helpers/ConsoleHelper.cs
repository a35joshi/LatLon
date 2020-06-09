using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JokeCompany.JokeGenerator.Application
{
    // All helper functions related to the Console go here.
    class ConsoleHelper
    {
        // Best way to check if a response from the user is a Yes/No.
        readonly Regex no = new Regex(@"^\s*[nN]([oO])?\s*$");
        readonly Regex yes = new Regex(@"^\s*[yY]([eE][sS])?\s*$");

        // Enumerator to encode and decode responses in a systematic manner.
        enum ValidResponse
        {
            Yes,
            No
        }
        
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        // Use this function when you expect a true/false type of response from the user
        public bool GetBooleanResponse(string question)
        {
            Console.WriteLine($"{question} {ApplicationConstants.YES_OR_NO} \n");
            ValidResponse? response = default;
            while (!response.HasValue)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (yes.IsMatch(line))
                    {
                        response = ValidResponse.Yes;
                    }
                    if (no.IsMatch(line))
                    {
                        response = ValidResponse.No;
                    }
                }
                if (!response.HasValue)
                {
                    Console.WriteLine(ApplicationConstants.INVALID_RESPONSE);
                }
            }

            return (response.Value == ValidResponse.Yes);
        }

        // Use this function when you give the user a list and you expect them to choose an item from it.
        public string GetListResponse(List<string> options)
        {
            while (true)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(options[i].ToLower())}");
                }

                Console.WriteLine("Enter the number next to your corresponding option. \n");
                string option = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(option))
                {
                    if (int.TryParse(option, out int optionIndex))
                    {
                        // An actual number has been entered
                        if (optionIndex > 0 && optionIndex <= options.Count)
                        {
                            return options[optionIndex - 1];
                        }
                    }
                    else
                    {
                        // If someone enters the actual text instead.
                        string correspondingOption = options.Find(x => x.Equals(option.ToLower()));

                        if (correspondingOption != null)
                        {
                            return correspondingOption;
                        }
                    }
                }

                Console.WriteLine(ApplicationConstants.INVALID_RESPONSE);
            }
        }

        // Use this function when you expect a numerical response from the user.
        public int GetIntResponse(string question)
        {
            int response = 0;

            while (response == 0)
            {
                WriteLine($"{question} \n");
                string number = Console.ReadLine();

                response = !string.IsNullOrWhiteSpace(number) && int.TryParse(number, out int parsedInput) &&
                           parsedInput > ApplicationConstants.JOKE_LOWER_RANGE && 
                           parsedInput < ApplicationConstants.JOKE_UPPER_RANGE 
                           ? parsedInput : 0;

                if (response == 0)
                {
                    WriteLine(ApplicationConstants.INVALID_RESPONSE);
                }
            }

            return response;
        }

        public void OutputResults(List<string> results)
        {
            foreach (string result in results)
            {
                WriteLine($"{result} \n");
            }
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
