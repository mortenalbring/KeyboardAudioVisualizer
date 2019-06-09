﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RGB.NET.Core;

namespace KeyboardAudioVisualizer.Configuration
{
    public class ColorSerializer : JsonConverter
    {
        #region Methods

        public override bool CanConvert(Type objectType) => objectType == typeof(Color);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is Color color)) return;

            writer.WriteStartObject();
            writer.WritePropertyName("A");
            writer.WriteValue(color.A);
            writer.WritePropertyName("R");
            writer.WriteValue(color.R);
            writer.WritePropertyName("G");
            writer.WriteValue(color.G);
            writer.WritePropertyName("B");
            writer.WriteValue(color.B);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            if (jsonObject.Property("A").Value.ToObject<double>() > 1.0) //DarthAffe 09.06.2019: Convert old Settings
                return new Color(jsonObject.Property("A").Value.ToObject<byte>(),
                                 jsonObject.Property("R").Value.ToObject<byte>(),
                                 jsonObject.Property("G").Value.ToObject<byte>(),
                                 jsonObject.Property("B").Value.ToObject<byte>());
            else
                return new Color(jsonObject.Property("A").Value.ToObject<double>(),
                                 jsonObject.Property("R").Value.ToObject<double>(),
                                 jsonObject.Property("G").Value.ToObject<double>(),
                                 jsonObject.Property("B").Value.ToObject<double>());
        }

        #endregion
    }
}
