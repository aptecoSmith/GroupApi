using APIStuff.Models.Audiences;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace APIStuff.ObritAPI
{
    public class Audiences
    {
        readonly string _baseURL;
        readonly string _dateView = "test";
        public string _accessToken;
        public string _userName = "joe.barradell@apteco.com";
        public string _systemName = "Test";
        private readonly OrbitAPIMethods _orbitAPIMethods;

        public Audiences(string baseURL)
        {
            _baseURL = baseURL;
            _orbitAPIMethods = new OrbitAPIMethods(baseURL);
        }

        public void GetAudiences(string localAccessToken, int count = 0, int? id = null)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
                return;
            }

            //set the url using the class variables and the variable passed from Program.cs
            var allAudienceURL = string.Join("/", _baseURL, _dateView, "/Audiences");
            var oneAudienceURL = string.Join("/", _baseURL, _dateView, "/Audiences/", id);

            if (id == null)
            {
                IRestClient client = new RestClient(allAudienceURL);
                //set up the rest API client and request 
                IRestRequest request = new RestRequest("", Method.GET);

                //add parameters to the request
                request.AddHeader("Authorization", "Bearer " + localAccessToken);

                //Do we want to change the default count?
                if (count > 0)
                {
                    request.AddParameter("count", count);
                }

                IRestResponse <ListOfAudiences.Root> response = client.Execute<ListOfAudiences.Root>(request);

                //execute the request through restAPI

                var audienceList = response.Data.list;

                //var text = JsonConvert.DeserializeObject<List<Audiences.Root>>(response);
                var json = JsonConvert.SerializeObject(response.Content, Formatting.Indented);
                File.WriteAllText(@"D:\Audiences.json", json);

                List<string> resultsList = new List<string>();

                foreach (var audience in audienceList)
                {
                    var title = audience.title;
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
            else
            {
                IRestClient client = new RestClient(oneAudienceURL);
                //set up the rest API client and request 
                IRestRequest request = new RestRequest("", Method.GET);

                //add parameters to the request
                request.AddHeader("Authorization", "Bearer " + localAccessToken);
                IRestResponse<SingleAudience.Root> response = client.Execute<SingleAudience.Root>(request);

                var text = JsonConvert.DeserializeObject(response.Content.ToString());
                var json = JsonConvert.SerializeObject(text, Formatting.Indented);
                File.WriteAllText(@"D:\Audience.json", json);

                string responseResult;
                if (response.IsSuccessful)
                {
                    responseResult = response.Data.title;
                    Console.WriteLine(responseResult);
                }
                else
                {
                    responseResult = response.StatusDescription;
                    Console.WriteLine(responseResult);
                }
            }
        }

        public int GetNamedAudienceId(string localAccessToken, string searchName)
        {
            int audienceId = 0;
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
                return 0;
            }

            //set the url using the class variables and the variable passed from Program.cs
            var allAudienceURL = String.Join("/", _baseURL, _dateView, "/Audiences");

            IRestClient client = new RestClient(allAudienceURL);
            //set up the rest API client and request 
            IRestRequest request = new RestRequest("", Method.GET);

            //add parameters to the request
            request.AddHeader("Authorization", "Bearer " + localAccessToken);
            request.AddParameter("count", "5000");

            Console.WriteLine("Getting response");
            //execute the request through restAPI
            IRestResponse<ListOfAudiences.Root> response = client.Execute<ListOfAudiences.Root>(request);

            Console.WriteLine("Response received");
            var audienceList = response.Data.list;

            List<string> resultsList = new List<string>();

            Console.WriteLine("Linq processing");
            var audienceDefinition = audienceList.FirstOrDefault(x => x.title == searchName);
            audienceId = audienceDefinition.id;

            //make json pretty
            var json = JsonConvert.SerializeObject(audienceDefinition, Formatting.Indented);
            //save to file
            File.WriteAllText(@"D:\SingleAudience.json", json);

            Console.WriteLine("For loop processing");
            foreach (var audience in audienceList)
            {
                Console.WriteLine(audience.title);
            }

            return audienceId;
        }

        public CreateAudience.Root ReadAudienceJsonFile(string filePath)
        {
            var readFile = File.ReadAllText($@"{filePath}");
            CreateAudience.Root objectJson = JsonConvert.DeserializeObject<CreateAudience.Root>(readFile);

            return objectJson;
        }

        public CreateAudience.Root ChangeAudienceJsonObjectTitle(CreateAudience.Root audience, string newTitle)
        {
            audience.title = newTitle;

            return audience;
        }

        public string SerializeEditiedAudience(CreateAudience.Root editedAudience)
        {
            var json = JsonConvert.SerializeObject(editedAudience, Formatting.Indented);

            return json;
        }

        public void CreateAudience(string localAccessToken, string json)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
            }

            var createAuidenceURL = String.Join("/", _baseURL, _dateView, "/Audiences");
            IRestClient client = new RestClient(createAuidenceURL);
            //set up the rest API client and request 
            IRestRequest request = new RestRequest("", Method.POST);

            //add parameters to the request
            request.AddHeader("Authorization", "Bearer " + localAccessToken);
            //ensure correct media type
            request.AddHeader("Accept", "application/json");
            //add the json to body
            request.AddJsonBody(json);

            IRestResponse<CreateAudience.Root> response = client.Execute<CreateAudience.Root>(request);

            //get the location of created audience from the response header
            var location = response.Headers[2];

            Console.WriteLine(location);
        }

    }
}
