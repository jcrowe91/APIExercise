using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIExercise
{
    class ChatBot
    {
        public static void MainActivity()
        {
            //create an instance of BaseServiceCall class and pass in a new HttpClient instance
            BaseServiceCall serviceCall = new BaseServiceCall(new HttpClient());
            
            for (int i = 0; i < 5; i++)
            {
                //uses instance methods from serviceCall object to get both quotes
                var kanyeQuote = serviceCall.GetKanyeQuote();
                var ronQuote = serviceCall.GetRonQuote();

                //writing quote to console
                ConsoleLogging.PassMessage("");
                ConsoleLogging.PassMessage($"Kanye: \"{kanyeQuote}\"");

                //delaying chat based on number of milliseconds
                DelayChat(800);

                //writing quote to console
                ConsoleLogging.PassMessage("");
                ConsoleLogging.PassMessage($"Swanson: {ronQuote}");

                //delaying chat
                DelayChat(800);
            }
        }

        private static void DelayChat(int delayInMilliseconds)
        {
            Thread.Sleep(delayInMilliseconds);
        }
    }
}
