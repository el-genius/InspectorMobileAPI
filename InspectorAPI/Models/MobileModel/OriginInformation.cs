namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class OriginInformation
    {
        [JsonProperty("origin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Origin { get; set; } = "public_library";

        [JsonProperty("origin_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string OriginId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("date_imported", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateImported { get; set; } = DateTime.Now;
    }
}
