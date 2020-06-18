namespace InspectorAPI.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class ResponseSet
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("responses", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Response> Responses { get; set; }
        public ResponseSet()
        {
            Responses = new List<Response>();
        }
    }
}
