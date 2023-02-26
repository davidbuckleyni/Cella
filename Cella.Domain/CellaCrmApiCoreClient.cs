using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cella.Domain.Interfaces;
using Cella.Models;
using Microsoft.Extensions.Configuration;

namespace Cella.Domain
{
    public class CellaCrmApiCoreClient  
    {
        private RestClient client;
      

        private readonly RestClient _client;
        public User User { get; set; }

        public string bearerToken { get; set; }
        private IConfiguration _config;
        public CellaCrmApiCoreClient(IConfiguration config)
        {
            _client = new RestClient();
            _config = config;
            User = new User();
            User.FirstName = "David";
            User.LastName = "Test12345";
        }

        public string token { get; set; }
        public async void AddAuthenicationHeader()
        {
        //    string bearerToken = await GenerateBarrerToken();
          //  client.Authenticator = new JwtAuthenticator(bearerToken);

        }

        //public async Task<string> GenerateBarrerToken()
        //{
        //    var json = JsonConvert.SerializeObject(User);            
        //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //    // Do the actual request and await the response
        // //   var request = new RestRequest("authentication", Method.POST);
        //    request.AddParameter("application/json", httpContent, ParameterType.RequestBody);
        //    RestResponse response = (RestResponse)client.Execute(request);
        //    HttpStatusCode statusCode = response.StatusCode;

        //    if (statusCode == System.Net.HttpStatusCode.OK)
        //    {

        //        var jsonContent = JsonConvert.DeserializeObject<string>(response.Content);
        //        var tok = JsonConvert.DeserializeObject<AuthenicationResponseOjbect>(jsonContent);
        //        token = tok.JwtToken;
        //    }
        //    return token;
        //}


    }
}
