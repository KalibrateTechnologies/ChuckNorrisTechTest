using System.Collections.Generic;

namespace Kalibrate.Chuck.Norris.Models
{
    public class SearchResponse
    {
        public int Total { get; set; }
        public List<Joke> Result { get; set; } = new List<Joke>();
    }
}