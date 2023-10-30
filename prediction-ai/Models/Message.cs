using System;
using System.Text.Json.Serialization;

namespace prediction_ai.Models
{
    internal class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}

