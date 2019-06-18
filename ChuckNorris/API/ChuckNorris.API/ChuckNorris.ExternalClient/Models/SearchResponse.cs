using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorris.ExternalClient.Models
{
    public class SearchResponse
    {
        public int total { get; set; }
        public List<Joke> result { get; set; }
    }
}
