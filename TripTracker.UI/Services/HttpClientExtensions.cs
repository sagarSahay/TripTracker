﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TripTracker.UI.Services
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent httpContent)
        {
            using (var stream = await httpContent.ReadAsStreamAsync())
            {
                var jsonReader = new JsonTextReader(new System.IO.StreamReader(stream));

                return _jsonSerializer.Deserialize<T>(jsonReader);
            }
        }

        public static Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient client, string url, T value)
        {
            return SendJsonAsync<T>(client, HttpMethod.Post, url, value);
        }
        public static Task<HttpResponseMessage> PutJsonAsync<T>(this HttpClient client, string url, T value)
        {
            return SendJsonAsync<T>(client, HttpMethod.Put, url, value);
        }

        public static Task<HttpResponseMessage> SendJsonAsync<T>(this HttpClient client, HttpMethod method, string url, T value)
        {
            var stream = new System.IO.MemoryStream();
            var jsonWriter = new JsonTextWriter(new System.IO.StreamWriter(stream));

            _jsonSerializer.Serialize(jsonWriter, value);

            jsonWriter.Flush();

            stream.Position = 0;

            var request = new HttpRequestMessage(method, url)
            {
                Content = new StreamContent(stream)
            };

            request.Content.Headers.TryAddWithoutValidation("Content-Type", "application/json");

            return client.SendAsync(request);
        }
    }

}