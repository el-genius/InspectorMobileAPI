namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Response
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("label", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("score", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Score { get; set; }

        [JsonProperty("colour", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Colour? Colour { get; set; }

        [JsonProperty("enable_score", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableScore { get; set; }

        [JsonProperty("failed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Failed { get; set; }
    }
}
