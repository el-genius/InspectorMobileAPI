namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class Metrics
    {
        [JsonProperty("rating", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Rating { get; set; } = -1;

        [JsonProperty("use_count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? UseCount { get; set; } = 0;

        [JsonProperty("avg_duration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? AvgDuration { get; set; } = 0;

        [JsonProperty("est_duration", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? EstDuration { get; set; } = -1;

        [JsonProperty("date_last_used", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? DateLastUsed { get; set; } = 0;

        [JsonProperty("duration_count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? DurationCount { get; set; } = 0;
    }
}
