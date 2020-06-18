namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class Metrics
    {
        [JsonProperty("rating", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Rating { get; set; }

        [JsonProperty("use_count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? UseCount { get; set; }

        [JsonProperty("avg_duration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? AvgDuration { get; set; }

        [JsonProperty("est_duration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? EstDuration { get; set; }

        [JsonProperty("date_last_used", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? DateLastUsed { get; set; }

        [JsonProperty("duration_count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? DurationCount { get; set; }
    }
}
