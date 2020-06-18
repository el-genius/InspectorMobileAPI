namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class Author
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("context", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Context { get; set; }
    }
}
