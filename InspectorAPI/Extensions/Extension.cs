using System;
using InspectorAPI.Models;
using Newtonsoft.Json;

namespace InspectorAPI.Extensions
{ 
    public static class Serialize
    {
        public static string ToJson(this Templates self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
