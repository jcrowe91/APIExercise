using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A randomized conversation between Kanye West and Ron Swanson:");
              var userContinue = "y";
            while(userContinue.ToLower() == "y")
            {               
                for (int i = 0; i < 5; i++)
                {
                    
                    var kanyeURL = "https://api.kanye.rest";
                    var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
                    var clientKanye = new HttpClient();
                    var clientRon = new HttpClient();
                    var kanyeResponse = clientKanye.GetStringAsync(kanyeURL).Result;
                    var ronResponse = clientRon.GetStringAsync(ronURL).Result;
                    var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                    Console.WriteLine("");
                    Console.WriteLine($"Kanye: \"{kanyeQuote}\"");
                    Console.WriteLine("");
                    Console.WriteLine($"Swanson: {ronQuote}");                                     
                }

                Console.WriteLine("------------");
                Console.WriteLine("Would you like to randomize another conversation? Y/N");
                userContinue = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Goodbye!");
        }
    }
}
