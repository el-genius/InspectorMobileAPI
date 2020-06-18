namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class Permissions
    {
        [JsonProperty("edit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Edit { get; set; }

        [JsonProperty("view", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string[] View { get; set; }

        [JsonProperty("owner", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Owner { get; set; }

        [JsonProperty("delete", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Delete { get; set; }

        [JsonProperty("context", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Context { get; set; }
    }
}
