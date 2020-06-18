namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Metadata
    {
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Image { get; set; }

        [JsonProperty("doc_no", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DocNo { get; set; }

        [JsonProperty("industry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Industry { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("subindustry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Subindustry { get; set; }

        [JsonProperty("doc_no_prefix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DocNoPrefix { get; set; }

        [JsonProperty("doc_no_suffix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DocNoSuffix { get; set; }

        [JsonProperty("audit_title_rule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid[] AuditTitleRule { get; set; }
    }
}
