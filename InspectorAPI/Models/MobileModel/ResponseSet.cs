namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class ResponseSet
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type { get; set; }

        [JsonProperty("responses", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Response[] Responses { get; set; }
    }
}
