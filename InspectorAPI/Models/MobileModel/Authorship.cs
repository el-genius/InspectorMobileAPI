namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Authorship
    {
        [JsonProperty("owner", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Author Owner { get; set; }

        [JsonProperty("author", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Author Author { get; set; }

        [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("language", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("device_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; set; }

        [JsonProperty("date_synced", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateSynced { get; set; }

        [JsonProperty("date_created", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateCreated { get; set; }

        [JsonProperty("date_modified", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateModified { get; set; }

        [JsonProperty("date_downloaded")]
        public object DateDownloaded { get; set; }
    }
}
