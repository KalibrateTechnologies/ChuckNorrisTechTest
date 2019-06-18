using System.Threading.Tasks;
using ChuckNorris.ExternalClient;
using Microsoft.AspNetCore.Mvc;
using ChuckNorris.ExternalClient.Models;

namespace ChuckNorris.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckNorrisController : ControllerBase
    {
        private readonly IChuckNorrisClient _chuckNorrisClient;

        public ChuckNorrisController(IChuckNorrisClient chuckNorrisClient)
        {
            _chuckNorrisClient = chuckNorrisClient;
        }
        
        [HttpGet]
        public async Task<ActionResult<Joke>> Get()
        {
            return Ok(await _chuckNorrisClient.GetRandomJoke());
        }
    }
}
