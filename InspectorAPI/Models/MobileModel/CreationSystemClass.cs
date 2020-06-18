namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class CreationSystemClass
    {
        [JsonProperty("os", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Os { get; set; }

        [JsonProperty("build", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Build { get; set; }

        [JsonProperty("model", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        [JsonProperty("version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("platform", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("device_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceName { get; set; }

        [JsonProperty("manufacturer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Manufacturer { get; set; }
    }
}
