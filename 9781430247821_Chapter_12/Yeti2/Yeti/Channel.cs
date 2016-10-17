using Newtonsoft.Json;

namespace Yeti
{
    public class Channel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "channeluri")]
        public string ChannelUri { get; set; }
    }
}
