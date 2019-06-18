using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorris.ExternalClient.Models
{
    public class Joke
    {
        public string category { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}
