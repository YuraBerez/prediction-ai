using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace prediction_ai.Models
{
	internal class AIRequest
	{
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }
    }
}

