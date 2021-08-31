using APIStuff.Models.Dashboards;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APIStuff.ObritAPIMethods
{
    public class Dashboards
    {
        readonly string _baseURL;
        readonly string _dateView = "test";
        public string _accessToken;
        public string _userName = "joe.barradell@apteco.com";
        public string _systemName = "Test";
        private readonly OrbitAPIMethods _orbitAPIMethods;

        public Dashboards(string baseURL)
        {
            _baseURL = baseURL;
            _orbitAPIMethods = new OrbitAPIMethods(baseURL);
        }

        public void GetAllUserDashboards(string localAccessToken, int count)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
                return;
            }

            //set the url using the class variables and the variable passed from Program.cs
            var url = string.Join("/", _baseURL, _dateView, "/Users/", _userName, "/Dashboards");

            //set up the rest API client and request 
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            //add parameters to the request
            request.AddHeader("Authorization", "Bearer " + localAccessToken);

            //Do we want to change the default count?
            if (count > 0)
            {
                request.AddParameter("count", count);
            }

            //execute the request through restAPI
            IRestResponse<UserDashboards.Root> response = client.Execute<UserDashboards.Root>(request);

            var dashboardList = response.Data.list;

            var text = JsonConvert.DeserializeObject(response.Content.ToString());
            var json = JsonConvert.SerializeObject(text, Formatting.Indented);
            File.WriteAllText(@"D:\UserDashboards.json", json);


            List<string> resultsList = new List<string>();

            foreach (var dashboard in dashboardList)
            {
                var title = dashboard.title;
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

        public void GetSingleUserDashboard(string localAccessToken)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
                return;
            }

            var url = string.Join("/", _baseURL, "Test/Users/JohnS/Dashboards/3");
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", "Bearer " + localAccessToken);
            IRestResponse<SingleUserDashboard.Root> response = client.Execute<SingleUserDashboard.Root>(request);

            var text = JsonConvert.DeserializeObject(response.Content.ToString());
            var json = JsonConvert.SerializeObject(text, Formatting.Indented);
            File.WriteAllText(@"D:\SingleUserDashboard.json", json);

        }

        public CreateDashboard.Root ReadDashboardJsonFile(string filePath)
        {
            var readFile = File.ReadAllText($@"{filePath}");
            CreateDashboard.Root objectJson = JsonConvert.DeserializeObject<CreateDashboard.Root>(readFile);

            return objectJson;
        }

        public CreateDashboard.Root ChangeDashboardJsonObjectTitle(CreateDashboard.Root dashboard, string newTitle)
        {
            dashboard.title = newTitle;

            return dashboard;
        }

        public string SerializeEditiedDashboard(CreateDashboard.Root editedDashboard)
        {
            var json = JsonConvert.SerializeObject(editedDashboard, Formatting.Indented);

            return json;
        }

        public void CreateDashboard(string localAccessToken, string json)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
            }

            var createDashboardURL = string.Join("/", _baseURL, _dateView, "/Dashboards");
            IRestClient client = new RestClient(createDashboardURL);
            //set up the rest API client and request 
            IRestRequest request = new RestRequest("", Method.POST);

            //add parameters to the request
            request.AddHeader("Authorization", "Bearer " + localAccessToken);
            //ensure correct media type
            request.AddHeader("Accept", "application/json");
            //add the json to body
            request.AddJsonBody(json);

            IRestResponse<CreateDashboard.Root> response = client.Execute<CreateDashboard.Root>(request);

            //get the location of created audience from the response header
            var location = response.Headers[2];

            Console.WriteLine(location);
        }
    }
}
