namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class ItemOptions
    {
        [JsonProperty("weighting", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Weighting { get; set; }

        [JsonProperty("is_mandatory", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMandatory { get; set; }

        [JsonProperty("response_set", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ResponseSet { get; set; }

        [JsonProperty("failed_responses", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid[] FailedResponses { get; set; }

        [JsonProperty("is_custom_failed_responses", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCustomFailedResponses { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type { get; set; }
    }
}
