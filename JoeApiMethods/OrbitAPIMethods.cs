using APIStuff.Models;
using APIStuff.Models.Audiences;
using APIStuff.Models.Collections;
using APIStuff.Models.Dashboards;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace APIStuff
{
    public class OrbitAPIMethods
    {
        readonly string _baseURL;
        readonly string _dateView = "test";
        public string _accessToken;
        public string _userName = "joe.barradell@apteco.com";
        public string _systemName = "Test";
        public OrbitAPIMethods(string baseURL)
        {
            _baseURL = baseURL;
        }

        public void GetAPIVersion()
        {
            //set the url using the class variables and the variable passed from Program.cs
            var url = String.Join("/", _baseURL, "About/Version");

            //set up the rest API client and request 
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);
            IRestResponse response = client.Execute(request);

            string responseResult;
            //if we are successful
            if (response.IsSuccessful)
            {
                //assign the content to a variable as a string from the API response
                responseResult = response.Content.ToString();
            }
            else
            {
                //return the status description from the API response
                responseResult = response.Content.ToString();
            }

            Console.WriteLine(responseResult);
        }

        public string GetAuthToken()
        {
            //set the url using the class variables and the variable passed from Program.cs
            var url = String.Join("/", _baseURL, _dateView, "/Sessions/SimpleLogin");

            //set up the rest API client and request 
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.POST);

            //add parameters to the request
            request.AddParameter("dataViewName", "Test");
            request.AddParameter("UserLogin", "JohnS");
            request.AddParameter("Password", "Password@2");

            //execute the request through restAPI
            IRestResponse response = client.Execute(request);

            var responseResult = "";
            //if we are successful
            if (!response.IsSuccessful)
            {
                //return the status description from the API response and return the variable
                responseResult = response.StatusDescription;
                Console.WriteLine(responseResult);
                return responseResult;
            }
            else
            {
                //return the status description from the API response
                responseResult = response.Content.ToString();
            }


            //deserialze json into simple login.root
            var result = JsonConvert.DeserializeObject<SimpleLogin.Root>(responseResult);

            //assign the access token from the response to the variable
            _accessToken = result.accessToken;

            //write the line the the console
            Console.WriteLine(_accessToken);

            //return the variable to the method
            return _accessToken;
        }

        public void GetAllUserCampaigns(string localAccessToken)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
                return;
            }

            //set the url using the class variables and the variable passed from Program.cs
            var url = String.Join("/", _baseURL, _dateView, "/PeopleStage", _systemName, "/Elements");

            //set up the rest API client and request 
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            //add parameters to the request
            request.AddHeader("Authorization", "Bearer " + localAccessToken);
            //request.AddParameter("count", "100");

            //execute the request through restAPI
            IRestResponse<PeopleStageElements.Root> response = client.Execute<PeopleStageElements.Root>(request);

            var campaignList = response.Data.list;

            List<string> resultsList = new List<string>();

            foreach (var campaign in campaignList)
            {
                var title = campaign.description;
                resultsList.Add(title);
            }

            string responseResult;
            if (response.IsSuccessful)
            {
                foreach (var item in resultsList)
                {
                    Console.Write("{0}\t", item.ToString());
                }
            }
            else
            {
                responseResult = response.StatusDescription;
                Console.WriteLine(responseResult);
            }
        }
    }
}