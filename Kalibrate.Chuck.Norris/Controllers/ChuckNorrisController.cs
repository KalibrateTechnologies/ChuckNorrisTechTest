using Kalibrate.Chuck.Norris.Models;
using Kalibrate.Chuck.Norris.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kalibrate.Chuck.Norris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckNorrisController : ControllerBase
    {
        private readonly IChuckNorrisService _chuckNorrisService;

        public ChuckNorrisController(IChuckNorrisService chuckNorrisService)
        {
            _chuckNorrisService = chuckNorrisService;
        }

        [HttpGet]
        public async Task<ActionResult<Joke>> Get()
        {
            return await _chuckNorrisService.GetRandomJoke();
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<List<Joke>>> Search([FromQuery] string query)
        {
            return (await _chuckNorrisService.Search(query)).ToList();
        }
    }
}