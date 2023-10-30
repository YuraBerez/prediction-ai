using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace prediction_ai.Models
{
    internal class AIResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("oobject")]
        public string Oobject { get; set; }
        [JsonPropertyName("created")]
        public int Created { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("choices")]
        public List<Choice> Choices { get; set; }
        [JsonPropertyName("usage")]
        public Usage Usage { get; set; }
    }

    internal class Choice
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("message")]
        public Message Message { get; set; }
        [JsonPropertyName("finish_reason")]
        public string Finish_reason { get; set; }
    }

    internal class Usage
    {
        [JsonPropertyName("prompt_tokens")]
        public int Prompt_tokens { get; set; }
        [JsonPropertyName("completion_tokens")]
        public int Completion_tokens { get; set; }
        [JsonPropertyName("total_tokens")]
        public int Total_tokens { get; set; }
    }


}

