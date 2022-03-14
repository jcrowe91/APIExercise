using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIExercise
{
    class BaseServiceCall
    {
        const string KANYE_URL = "https://api.kanye.rest";
        const string RON_URL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        //private readonly field
        private readonly HttpClient _client;

        //inject an instance of a HTTPClient
        public BaseServiceCall(HttpClient client)
        {
            //intitilize the field _client with the client object that is passed through
            _client = client;
        }
        

        public string GetKanyeQuote()
        {            
            var kanyeResponse = _client.GetStringAsync(KANYE_URL).Result;
            //parsing kanyeResponse, getting value of "quote" property, converting to string
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }

        public string GetRonQuote()
        {
            var ronResponse = _client.GetStringAsync(RON_URL).Result;
            //parsing ronResponse, converting to string, replacing [] with spaces, and trimming white space
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            return ronQuote;
        }
    }
}
