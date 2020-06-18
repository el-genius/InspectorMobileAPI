namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Item
    {
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("label", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("item_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ItemId { get; set; }

        [JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ItemOptions Options { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        public Item()
        {
            Options = new ItemOptions();
        }
    }
}
