using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ChuckNorris.ExternalClient.Models;

namespace ChuckNorris.ExternalClient
{
    public class ChuckNorrisClient : IChuckNorrisClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public ChuckNorrisClient(IHttpClientFactory clientFactory)
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
                return await response.Content.ReadAsAsync<Joke>();
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<string>> GetCategories()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/categories");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "f968e391b4msh9b687d65cd00d53p147229jsnddfb39298696");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<string>>();
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<SearchResponse> Search(string query)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/search?query={query}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "f968e391b4msh9b687d65cd00d53p147229jsnddfb39298696");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResponse>();
            }

            throw new Exception(response.ReasonPhrase);
        }
    }
}
