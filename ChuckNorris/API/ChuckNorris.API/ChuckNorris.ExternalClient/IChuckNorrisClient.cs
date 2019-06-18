using System.Collections.Generic;
using System.Threading.Tasks;
using ChuckNorris.ExternalClient.Models;

namespace ChuckNorris.ExternalClient
{
    public interface IChuckNorrisClient
    {
        Task<Joke> GetRandomJoke();
        Task<List<string>> GetCategories();
        Task<SearchResponse> Search(string query);
    }
}
