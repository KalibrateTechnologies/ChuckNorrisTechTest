using Kalibrate.Chuck.Norris.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kalibrate.Chuck.Norris.Services
{
    public interface IChuckNorrisService
    {
        Task<Joke> GetRandomJoke();

        Task<IEnumerable<Joke>> Search(string query);
    }
}