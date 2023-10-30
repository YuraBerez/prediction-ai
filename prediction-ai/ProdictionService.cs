using System;
using System.Threading.Tasks;
using prediction_ai.Models;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;

namespace prediction_ai
{
    public class ProdictionService
    {
        #region members
        private string? _apiKey = null;
        private string _language = "En";
        #endregion

        #region constructors
        public ProdictionService() { }

        public ProdictionService(string apiKey, string? language = null)
        {
            _apiKey = apiKey;
            _language = language ?? _language;
        }
        #endregion

        #region public methods
        public void Configure(string apiKey, string? language = null)
        {
            _apiKey = apiKey;
            _language = language ?? _language;
        }

        public async Task<string> GetProdictionAsync()
        {
            if (_apiKey == null)
            {
                throw new Exception("API key is required.");
            }

            var result = await GetPredictionFromAIAsync(new AIRequest
            {
                Model = "gpt-4-0613", // GPT model
                Messages = new List<Message>
                {
                    new Message
                    {
                        Role = "system",
                        Content = $"\"You are generate predictions, return string predictions. The predictions are random texts that will cheer you up or teach you something. Return only one prediction for language - {_language}. Return in format: <prediction text>\""
                    },
                    new Message
                    {
                        Role = "user",
                        Content = $"Get prediction for language: {_language}"
                    }
                }
            });

            return ProceedContent(result?.Choices[0]?.Message.Content ?? string.Empty);
        }
        #endregion

        #region private methods
        private async Task<AIResponse?> GetPredictionFromAIAsync(AIRequest aIRequest)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.openai.com/v1/chat/completions"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_apiKey}");
                    request.Content = new StringContent(JsonSerializer.Serialize(aIRequest));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Wrong API key.");
                    }
                    else
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new Exception("Bad request");
                    }

                    return JsonSerializer.Deserialize<AIResponse>(await response.Content.ReadAsStringAsync());
                }
            }
        }

        private string ProceedContent(string inputString)
        {
            return inputString.Replace("\"", string.Empty);
        }
        #endregion
    }
}

