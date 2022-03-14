using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //opening message
            ConsoleLogging.PassMessage("A randomized conversation between Kanye West and Ron Swanson:");

            string userContinue = "y";

            do
            {
                //executes main activity until user is ready to exit
                ChatBot.MainActivity();

                ConsoleLogging.PassMessage("------------");
                ConsoleLogging.PassMessage("Would you like to randomize another conversation? Y/N");
                userContinue = Console.ReadLine();

                ConsoleLogging.ClearConsole();
            } while (userContinue.ToLower() == "y");

            //closing message
            ConsoleLogging.PassMessage("Goodbye!");
        }
    }
}
