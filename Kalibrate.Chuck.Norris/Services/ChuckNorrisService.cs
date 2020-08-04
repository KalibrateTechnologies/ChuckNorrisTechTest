using Kalibrate.Chuck.Norris.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kalibrate.Chuck.Norris.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly IHttpClientFactory _clientFactory;
        JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public ChuckNorrisService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Joke> GetRandomJoke()
        {
            var request = CreateGetRequest("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Joke>(stream, _jsonOptions);
            }

            throw new Exception(response.ReasonPhrase);
        }

        public async Task<IEnumerable<Joke>> Search(string query)
        {
            var request = CreateGetRequest($"https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/search?query={query}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                return (await JsonSerializer.DeserializeAsync<SearchResponse>(stream, _jsonOptions)).Result;
            }

            throw new Exception(response.ReasonPhrase);
        }

        private static HttpRequestMessage CreateGetRequest(string uri)
        {
            //GET https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/search?query={query}

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "f968e391b4msh9b687d65cd00d53p147229jsnddfb39298696");
            return request;
        }
    }
}