using Newtonsoft.Json;
using System.Collections.Generic;

namespace SnowyAlexa.Data
{
    [JsonObject]
    public class SnowRequest
    {
        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("impact")]
        public string Impact { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}



       