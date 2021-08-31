using APIStuff.Models.Collections;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APIStuff.ObritAPI
{
    public class Collections
    {
        readonly string _baseURL;
        readonly string _dateView = "test";
        public string _accessToken;
        public string _userName = "joe.barradell@apteco.com";
        public string _systemName = "Test";
        private readonly OrbitAPIMethods _orbitAPIMethods;

        public Collections(string baseURL)
        {
            _baseURL = baseURL;
            _orbitAPIMethods = new OrbitAPIMethods(baseURL);
        }


        public void GetCollections(string localAccessToken, int count = 0, int? id = null)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
                return;
            }

            //set the url using the class variables and the variable passed from Program.cs
            var allCollectionsURL = string.Join("/", _baseURL, _dateView, "/Collections");
            var oneCollectionURL = string.Join("/", _baseURL, _dateView, "/Collections/", id);

            if (id == null)
            {
                IRestClient client = new RestClient(allCollectionsURL);
                //set up the rest API client and request 
                IRestRequest request = new RestRequest("", Method.GET);

                //add parameters to the request
                request.AddHeader("Authorization", "Bearer " + localAccessToken);

                //Do we want to change the default count?
                if (count > 0)
                {
                    request.AddParameter("count", count);
                }

                IRestResponse<ListOfCollections.Root> response = client.Execute<ListOfCollections.Root>(request);

                //execute the request through restAPI

                var collectionList = response.Data.list;

                var json = JsonConvert.SerializeObject(response.Content, Formatting.Indented);
                File.WriteAllText(@"D:\Collections.json", json);

                List<string> resultsList = new List<string>();

                foreach (var collection in collectionList)
                {
                    var title = collection.title;
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
                IRestClient client = new RestClient(oneCollectionURL);
                //set up the rest API client and request 
                IRestRequest request = new RestRequest("", Method.GET);

                //add parameters to the request
                request.AddHeader("Authorization", "Bearer " + localAccessToken);
                IRestResponse<SingleCollection.Root> response = client.Execute<SingleCollection.Root>(request);

                var text = JsonConvert.DeserializeObject(response.Content.ToString());
                var json = JsonConvert.SerializeObject(text, Formatting.Indented);
                File.WriteAllText(@"D:\SingleCollection.json", json);

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


        public CreateCollection.Root ReadCollectionJsonFile(string filePath)
        {
            var readFile = File.ReadAllText($@"{filePath}");
            CreateCollection.Root objectJson = JsonConvert.DeserializeObject<CreateCollection.Root>(readFile);

            return objectJson;
        }

        public CreateCollection.Root ChangeCollectionJsonObjectTitle(CreateCollection.Root collection, string newTitle)
        {
            collection.title = newTitle;

            return collection;
        }

        public string SerializeEditiedCollection(CreateCollection.Root editedCollection)
        {
            var json = JsonConvert.SerializeObject(editedCollection, Formatting.Indented);

            return json;
        }

        public void CreateCollections(string localAccessToken, string json)
        {
            //access token must be valid
            if (localAccessToken == null)
            {
                Console.WriteLine("No valid access token");
            }

            var createCollectionURL = string.Join("/", _baseURL, _dateView, "/Collections");
            IRestClient client = new RestClient(createCollectionURL);
            //set up the rest API client and request 
            IRestRequest request = new RestRequest("", Method.POST);

            //add parameters to the request
            request.AddHeader("Authorization", "Bearer " + localAccessToken);
            //ensure correct media type
            request.AddHeader("Accept", "application/json");
            //add the json to body
            request.AddJsonBody(json);

            IRestResponse<CreateCollection.Root> response = client.Execute<CreateCollection.Root>(request);

            //get the location of created audience from the response header
            var location = response.Headers[2];

            Console.WriteLine(location);
        }
    }
}

