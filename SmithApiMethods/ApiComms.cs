using ApiMethods1.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMethods1.OrbitApi
{
    public class ApiComms
    {
        private string _baseUrl = "";
        private string _dataview = "";
        private string _authToken = "";

        public ApiComms(string passedInBaseUrl, string dataviewPassedIn)
        {
            _baseUrl = passedInBaseUrl;
            _dataview = dataviewPassedIn;
        }

        public IRestResponse ApiResponse(Method methodType, string endpoint, IRestRequest request)
        {
            string url = _baseUrl + endpoint;
            IRestClient client = new RestClient(url);
            if (_authToken != "")
            {
                request.AddHeader("Authorization", $"Bearer {_authToken}");
            }
            else
            {
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        public void GetAuthToken(string username, string password)
        {
            string endpoint = $"{_dataview}/Sessions/SimpleLogin";
            var methodType = Method.POST;
            IRestRequest request = new RestRequest(methodType);
            request.AddParameter("UserLogin", username);
            request.AddParameter("Password", password);

            IRestResponse response = ApiResponse(methodType, endpoint, request);

            var responseIntoClass = JsonConvert.DeserializeObject<SimpleLogin.Root>(response.Content);

            if (response.IsSuccessful)
            {
                _authToken = responseIntoClass.accessToken;
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }

            Console.WriteLine();
        }
    }
}