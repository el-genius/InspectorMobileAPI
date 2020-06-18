namespace InspectorAPI.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class TemplateData
    {
        [JsonProperty("media", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Media> Media { get; set; }

        [JsonProperty("metrics", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Metrics Metrics { get; set; }

        [JsonProperty("metadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Metadata Metadata { get; set; }

        [JsonProperty("authorship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Authorship Authorship { get; set; }

        [JsonProperty("versioning", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Versioning Versioning { get; set; }

        [JsonProperty("response_sets", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ResponseSet> ResponseSets { get; set; }

        [JsonProperty("origin_information", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public OriginInformation OriginInformation { get; set; }

        [JsonProperty("mandatory_mark_as_complete", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? MandatoryMarkAsComplete { get; set; } = false;
        public TemplateData()
        {
            ResponseSets = new Dictionary<string, ResponseSet>();
        }
    }
}
