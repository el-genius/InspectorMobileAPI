namespace InspectorAPI.Models
{
    using Newtonsoft.Json;

    public partial class Versioning
    {
        [JsonProperty("creation_system", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public CreationSystemClass CreationSystem { get; set; }

        [JsonProperty("last_edited_system", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public CreationSystemClass LastEditedSystem { get; set; }
    }
}
