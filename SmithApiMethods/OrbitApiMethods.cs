using ApiMethods1.Models;
using ApiMethods1.OrbitApi;
using ApiMethods1.OrbitApi.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiMethods1
{
    public class OrbitApiMethods
    {
        public string _swaggerUrl = "https://cloudtest.faststats.co.uk/Test/OrbitAPI/swagger/ui/index.html";
        public string _apiUrl = "https://cloudtest.faststats.co.uk/Test/OrbitAPI/";
        public string _aboutEndpoint = "";
        public string _loginEndpoint = "";
        private string _dataview = "test";
        public string _password = "Password@2";
        public string _username = "johns";
        public string _FileSaveFolder = @"C:\temp";

        public ApiComms _ac;

        public OrbitApiMethods(string loginEndPointPassedIn = "")
        {
            /*
             *
             * This is a class constructor.
             * It is a method that runs when the class is instantiated, and is usually used to assign to variables upon instantiation
             * You can pass paramaters in to this method, which effectively means passing a variable in to the class
             *
             * Note how the swagger Url is hardcoded to the class
             * but the apiUrl is only assigned when the class is instantiated, as it is assigned in this constructor.
             * our 'loginEndPointPassedIn' has a default value of "".
             * This means that you can choose whether to pass in this paramater or not.
             * default/ optional params are always last in the paramater brackets.
             * */
            _loginEndpoint = loginEndPointPassedIn;
            _aboutEndpoint = "https://cloudtest.faststats.co.uk/Test/OrbitAPI/";
            _ac = new ApiComms(_apiUrl, _dataview);
        }

        public void About()
        {
            string endpoint = _apiUrl + $"About/Version";
            IRestClient client = new RestClient(endpoint);
            IRestRequest request = new RestRequest("", Method.GET)/* { Credentials = new NetworkCredential("testUser", "P455w0rd") }*/;

            //request.AddHeader("Authorization", "Bearer qaPmk9Vw8o7r7UOiX-3b-8Z_6r3w0Iu2pecwJ3x7CngjPp2fN3c61Q_5VU3y0rc-vPpkTKuaOI2eRs3bMyA5ucKKzY1thMFoM0wjnReEYeMGyq3JfZ-OIko1if3NmIj79ZSpNotLL2734ts2jGBjw8-uUgKet7jQAaq-qf5aIDwzUo0bnGosEj_UkFxiJKXPPlF2L4iNJSlBqRYrhw08RK1SzB4tf18Airb80WVy1Kewx2NGq5zCC-SCzvJW-mlOtjIDBAQ5intqaRkwRaSyjJ_MagxJF_CLc4BNUYC3hC2ejQDoTE6HYMWMcg0mbyWghMFpOw3gqyfAGjr6LPJcIly__aJ5__iyt-BTkOnMpDAZLTjzx4qDHMPWeND-TlzKWXjVb5yMv5Q6Jg6UmETWbuxyTdvGTJFzanUg1HWzPr7gSs6GLEv9VDTMiC8a5sNcGyLcHBIJo8mErrZrIssHvbT8ZUPWtyJaujKvdgazqsrad9CO3iRsZWQJ3lpvdQwucCsyjoRVoj_mXYhz3JK3wfOjLff16Gy1NLbj4gmOhBBRb8rJnUXnP7rBHs00FAk59BIpKLIPIyMgYBApDCut8V55AgXtGs4MgFFiJKbuaKxq8cdMYEVBTzDJ-S1IR5d6eiTGusD5aFlUkAs9NV_nFw");
            //request.AddParameter("clientId", 123);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                response.Content.ToString();
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }

            Console.WriteLine();
        }

        public GetUserDashboardNullable.Root GetDashboardDefinition(string id = "3")
        {
            string endpoint = $"{_dataview}/Users/{_username}/Dashboards/{id}";
            var methodType = Method.GET;
            IRestRequest request = new RestRequest(methodType);

            IRestResponse response = _ac.ApiResponse(methodType, endpoint, request);

            var responseIntoClass = JsonConvert.DeserializeObject<GetUserDashboardNullable.Root>(response.Content);

            if (response.IsSuccessful)
            {
                //_authToken = responseIntoClass.accessToken;
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }

            Console.WriteLine();
            return responseIntoClass;
        }

        public void SaveDashboardDefinition(GetUserDashboardNullable.Root oldDash, string saveName = "SmithDash")
        {
            var json = JsonConvert.SerializeObject(oldDash, Formatting.Indented);
            var fileloc = Path.Join(_FileSaveFolder, saveName) + ".json";

            File.WriteAllText(fileloc, json);
            Console.WriteLine($"File written to {fileloc}");
        }

        public string LoadDashFromFile(string saveName = "SmithDash")
        {
            var fileloc = Path.Join(_FileSaveFolder, saveName) + ".json";
            var json = File.ReadAllText(fileloc);
            return json;
        }

        public GetUserDashboardNullable.Root ConvertDashJsonToObject(string json)
        {
            var obj = JsonConvert.DeserializeObject<GetUserDashboardNullable.Root>(json);

            return obj;
        }

        public GetUserDashboardNullable.Root NewTitleDashboardDefinition(GetUserDashboardNullable.Root dash, string newTitle)
        {
            dash.title = newTitle;
            return dash;
        }

        public bool CreateDashFromDefinition(GetUserDashboardNullable.Root dashObj)
        {
            string endpoint = $"{_dataview}/Dashboards";
            var methodType = Method.POST;
            IRestRequest request = new RestRequest(methodType);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(dashObj);

            IRestResponse response = _ac.ApiResponse(methodType, endpoint, request);

            var responseIntoClass = JsonConvert.DeserializeObject<GetUserDashboardNullable.Root>(response.Content);

            if (response.IsSuccessful)
            {
                //_authToken = responseIntoClass.accessToken;
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }

            Console.WriteLine();

            return true;
        }
    }
}