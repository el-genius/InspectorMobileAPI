namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Media
    {
        [JsonProperty("label", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("file_ext", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FileExt { get; set; }

        [JsonProperty("media_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? MediaId { get; set; }

        [JsonProperty("date_created", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateCreated { get; set; }
    }
}
