using Cella.Infrastructure;
using Cella.Models;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cella.BL.Services
{
    public class HttpClinetServices
    {

        private HttpClient httpClient;
        private HttpClientHandler _httpClientHandler;
        private const string ClientUserAgent = "my-api-client-v1";
        private const string MediaTypeJson = "application/json";
        private readonly TimeSpan _timeout;
        private readonly TimeSpan? Timeout;
        public string bearerToken { get; set; }

        public HttpClinetServices()
        {
            _timeout = Timeout ?? TimeSpan.FromSeconds(90);
            CreateHttpClient();
        }

        private void CreateHttpClient()
        {
            _httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            httpClient = new HttpClient(_httpClientHandler, false)
            {
                Timeout = _timeout
            };

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(ClientUserAgent);

            if (!string.IsNullOrWhiteSpace(Constants.BaseUrl))
            {
                httpClient.BaseAddress = new Uri(Constants.BaseUrl);
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
        }

        private void EnsureHttpClientCreated()
        {
            if (httpClient == null)
            {
                CreateHttpClient();
            }
        }

        public async Task<Authentication> ValidateUser(User user)
        {
            bool isValidUser = false;
            var json = JsonConvert.SerializeObject(user);
            string token = string.Empty;

            EnsureHttpClientCreated();
            AuthenicationResponseOjbect tok = new();

            using (var httpContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                try
                {
                    // Do the actual request and await the response
                    var httpResponse = await httpClient.PostAsync(Constants.BaseUrl + Constants.AuthUrl, httpContent);

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        isValidUser = true;
                        var jsonContent = await httpResponse.Content.ReadAsStringAsync();
                        tok = JsonConvert.DeserializeObject<AuthenicationResponseOjbect>(jsonContent);
                        token = tok.JwtToken;
                        bearerToken = tok.JwtToken;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., network issues, server errors) here
                    // You might want to log the exception for debugging purposes.
                }
            }

            if (isValidUser)
            {
                var auth = new Authentication
                {
                    FirstName = tok.FirstName,
                    LastName = tok.LastName,
                    JWTToken = bearerToken
                };
                return auth;
            }
            else
            {
                return null;
            }
        }

    }
}
