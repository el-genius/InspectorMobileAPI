namespace InspectorAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    using InspectorAPI.Logic.Helper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Templates
    {
        [JsonProperty("_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("_rev", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rev { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = "template";

        [JsonProperty("items", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> Items { get; set; }

        [JsonProperty("header", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Header[] Header { get; set; }

        [JsonProperty("deleted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; } = false;

        [JsonProperty("trashed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Trashed { get; set; } = false;

        [JsonProperty("libraryId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LibraryId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("created_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("modified_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ModifiedAt { get; set; }

        [JsonProperty("permissions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Permissions Permissions { get; set; }

        [JsonProperty("template_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateId { get; set; }

        [JsonProperty("revision_key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? RevisionKey { get; set; } = Guid.NewGuid();

        [JsonProperty("template_data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TemplateData TemplateData { get; set; }

        [JsonProperty("server_revision_key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ServerRevisionKey { get; set; } = Guid.NewGuid();


        public Templates()
        {
            this.Items = new List<Item>();
            TemplateData = new TemplateData();
        }

        public Templates(string id, string name, dynamic examinationMobileTemplate, dynamic answerMobileSet) : this()
        {
            this.Id = id;
            this.Name = name;
            FromJson(examinationMobileTemplate, answerMobileSet);
        }

        //JsonConvert.DeserializeObject<Templates>(json, Converter.Settings);
        public void FromJson(params dynamic[] json)
        {
            var examinations = json[0];
            var responses = json[1];
            SetQuestionItems(examinations);
            SetResponseSet(responses);
        }

        private void SetResponseSet(dynamic responses)
        {
            ResponseSet tempSet = null;
            foreach (var item in responses)
            {
                if (tempSet?.Id != null && tempSet?.Id != item.id.ToString())
                {
                    TemplateData.ResponseSets.Add(tempSet.Id, tempSet);
                }
                if (tempSet?.Id == null || tempSet?.Id != item.id.ToString())
                {
                    tempSet = new ResponseSet();
                    tempSet.Id = item.id;
                    tempSet.Type = item.type;
                }

                tempSet.Responses.Add(new Response()
                {
                    Colour = item.responses_color.ToString(),
                    Id = item.responses_id.ToString(),
                    Label = item.responses_label.ToString(),
                    Score =item.responses_score.ToString(),
                    EnableScore = bool.Parse(item.responses_enable_score.ToString())
                });
            }
            TemplateData.ResponseSets.Add(tempSet.Id, tempSet);
        }

        private void SetQuestionItems(dynamic examinations)
        {
            foreach (var item in examinations)
            {
                var tmpItem = new Item
                {
                    Type = item.type.ToString(),
                    Label = item.label.ToString(),
                    ItemId = item.item_id.ToString(),
                    ParentId = item.parent_id?.ToString(),
                };
                if (tmpItem.Type == "question")
                {
                    tmpItem.Options.Weighting = 1;
                    tmpItem.Options.IsMandatory = bool.Parse(item.options_is_mandatory.ToString());
                    tmpItem.Options.ResponseSet = item.options_response_set.ToString();
                    tmpItem.Options.IsCustomFailedResponses = false;
                    tmpItem.Options.FailedResponses = 2;
                }
                Items.Add(tmpItem);
            }
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                ColourConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "category":
                    return TypeEnum.Category;
                case "information":
                    return TypeEnum.Information;
                case "question":
                    return TypeEnum.Question;
                case "section":
                    return TypeEnum.Section;
                case "signature":
                    return TypeEnum.Signature;
                case "text":
                    return TypeEnum.Text;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Category:
                    serializer.Serialize(writer, "category");
                    return;
                case TypeEnum.Information:
                    serializer.Serialize(writer, "information");
                    return;
                case TypeEnum.Question:
                    serializer.Serialize(writer, "question");
                    return;
                case TypeEnum.Section:
                    serializer.Serialize(writer, "section");
                    return;
                case TypeEnum.Signature:
                    serializer.Serialize(writer, "signature");
                    return;
                case TypeEnum.Text:
                    serializer.Serialize(writer, "text");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class ColourConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Colour) || t == typeof(Colour?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "112,112,112":
                    return Colour.The112112112;
                case "19,133,95":
                    return Colour.The1913395;
                case "198,0,34":
                    return Colour.The198034;
                case "255,176,0":
                    return Colour.The2551760;
            }
            throw new Exception("Cannot unmarshal type Colour");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Colour)untypedValue;
            switch (value)
            {
                case Colour.The112112112:
                    serializer.Serialize(writer, "112,112,112");
                    return;
                case Colour.The1913395:
                    serializer.Serialize(writer, "19,133,95");
                    return;
                case Colour.The198034:
                    serializer.Serialize(writer, "198,0,34");
                    return;
                case Colour.The2551760:
                    serializer.Serialize(writer, "255,176,0");
                    return;
            }
            throw new Exception("Cannot marshal type Colour");
        }

        public static readonly ColourConverter Singleton = new ColourConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
