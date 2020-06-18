namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class HeaderOptions
    {
        [JsonProperty("is_mandatory", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMandatory { get; set; }

        [JsonProperty("enable_date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableDate { get; set; }

        [JsonProperty("enable_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableTime { get; set; }
    }
}
