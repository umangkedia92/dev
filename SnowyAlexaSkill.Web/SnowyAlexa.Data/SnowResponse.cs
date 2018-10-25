using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowyAlexa.Data
{
    [JsonObject("result")]
    public class SnowResponse
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("assignment_group")]
        public string AssignmentGroup { get; set; }

        [JsonProperty("caller_id")]
        public string CallerId { get; set; }

        [JsonProperty("sys_created_on")]
        public string CreatedOn { get; set; }

        [JsonProperty("impact")]
        public string Impact { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("sys_updated_on")]
        public string UpdatedOn { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }

    }
}