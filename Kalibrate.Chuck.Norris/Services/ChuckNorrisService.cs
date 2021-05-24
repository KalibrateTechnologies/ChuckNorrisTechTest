using Kalibrate.Chuck.Norris.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kalibrate.Chuck.Norris.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ChuckNorrisService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Joke> GetRandomJoke()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "f968e391b4msh9b687d65cd00d53p147229jsnddfb39298696");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Joke>(stream, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<Joke>> Search(string query)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/search?query={query}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "f968e391b4msh9b687d65cd00d53p147229jsnddfb39298696");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var listOfJokes = JObject.Parse(responseBody);                    
                    return listOfJokes["result"].ToObject<List<Joke>>();

                }
            }
            catch(Exception ex)
            {
                var error = ex;
            }
            throw new Exception(response.ReasonPhrase);


        }
    }
}