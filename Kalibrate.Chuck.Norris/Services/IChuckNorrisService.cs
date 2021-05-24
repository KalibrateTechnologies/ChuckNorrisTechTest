using Kalibrate.Chuck.Norris.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kalibrate.Chuck.Norris.Services
{
    public interface IChuckNorrisService
    {
        Task<Joke> GetRandomJoke();
        
        Task<List<Joke>> Search(string query);
    }
}