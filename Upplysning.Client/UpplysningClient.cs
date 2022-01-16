using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Upplysning
{
    public class UpplysningClient : IDisposable
    {
        private HttpClient _httpClient;

        public UpplysningClient()
        {
            HttpClientHandler handler = new();
            handler.AllowAutoRedirect = true;
            _httpClient = new HttpClient(handler);
        }

        public async Task<UpplysningPersonResult[]> GetPeopleAsync(string name, string? where = null)
        {
            var message = string.Format("who={0}&where={1}&x={2}", HttpUtility.UrlEncode(name.ToLower(), Encoding.GetEncoding("ISO-8859-1")), HttpUtility.UrlEncode(where?.ToLower(), Encoding.GetEncoding("ISO-8859-1")), UpplysningUrlHelper.GenerateToken());
            var content = new StringContent(message);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync("https://www.upplysning.se/person/", content);

            if (!response.IsSuccessStatusCode)
                throw new ArgumentException("Can't find any person matching the arguments.");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = await UpplysningPeopleParser.ParsePeopleAsync(responseString);

            return result;
        }

        public void Dispose() => _httpClient.Dispose();
    }
}
