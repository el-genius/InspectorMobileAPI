﻿namespace InspectorAPI.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Header
    {
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("label", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("item_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ItemId { get; set; }

        [JsonProperty("options", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public HeaderOptions Options { get; set; }

        [JsonProperty("parent_id")]
        public Guid? ParentId { get; set; }
    }
}
