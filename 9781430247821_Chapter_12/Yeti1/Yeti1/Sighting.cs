using System;
using Newtonsoft.Json;

namespace Yeti1
{
    public class Sighting
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "lastseen")]
        public DateTimeOffset LastSeen { get; set; }
    }
}