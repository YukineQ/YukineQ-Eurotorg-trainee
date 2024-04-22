using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Eurotorg_trainee.Helpers
{
    public sealed class ApiCall
    {
        public const string GET = "GET";
        public const string POST = "POST";
        public static HttpClient HttpClient { get; } = new HttpClient();

        public ValueTask<T> GetAsync<T>(string url, IEnumerable<(string, string)> parameters)
        {
            return RequestAsync<T>(url, GET, parameters);
        }

        private async ValueTask<T> RequestAsync<T>(
            string url,
            string method,
            IEnumerable<(string, string)> parameters = null
        ) 
        {
            var post = string.Equals(method, POST, StringComparison.Ordinal);
            IEnumerable<string> parameterString = null;

            var parray = parameters.ToArray();
            parameterString = parray.Select(p => $"{p.Item1}={p.Item2}");

            var request = new HttpRequestMessage();
            request.Headers.Add("Accept", "application/json");

            if(post)
            {
                request.Method = HttpMethod.Post;
                request.Content = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(string.Join("&", parameterString))));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            } 
            else
            {
                request.Method = HttpMethod.Get;
                url += $"?{string.Join("&", parameterString)}";
            }

            request.RequestUri = new Uri(url);
            var response = await HttpClient.SendAsync(request);
            var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync()).ConfigureAwait(false);

            return result == null ? throw new InvalidOperationException("JsonSerializer.DeserializeAsync return null") : result;
        }
    }
}
