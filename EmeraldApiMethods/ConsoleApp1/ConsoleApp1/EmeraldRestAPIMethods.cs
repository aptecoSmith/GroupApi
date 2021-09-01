using APIStuff.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GroupApi
{
    public class EmeraldRestAPIMethods
    {
        private string _baseUrl = "";
        public string _authToken = "";
        public string responseResult = "";

        public EmeraldsSimpleLogin LoginStuff = new EmeraldsSimpleLogin();
        public List<EmeraldsSimpleLogin> _logInStuff1 = new List<EmeraldsSimpleLogin>();

        public IRestResponse<EmeraldsAudiences.Root> audienceListResponse;
        public string returnAudID = "";
        public string audienceDefinition;
        public AudienceDetails.Root singleAudience;

        public List<string> dashboardTitles;
        public string returnDashID = "";
        public string dashboardDefinition;
        public DashboardDetails.Root singleDashboard;

        public List<string> collectionTitles;
        public string returnCollID = "";
        public string collectionDefinition;
        public CollectionDetails.Root singleCollection;

        public List<string> compositionDescriptions;
        public string returnCompID = "";
        public string compositionDefinition;
        public CompositionDetails.Root singleComposition;

        public List<string> campaignDescriptions;
        public string returnCampID = "";
        public string campaignDefinition;
        public CampaignDetails.Root singleCampaign;

        public string jsonOutput;

        public EmeraldRestAPIMethods(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        // public string folderPath = @"C:\Users\temp";

        public void CheckIfTempFolder()
        {
            string root = @"C:\Users\emera\temp";
            string subdir = @"C:\Users\emera\temp\OrbitTests"; // can i get rid of emera
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
        }
        public void GetAuthToken()
        {
            var url = string.Join("/", _baseUrl, "Test/Sessions/SimpleLogin");
            // Call the version endpoint of the orbit API
            // var url = "https://cloudtest.faststats.co.uk/Test/OrbitAPI/About/Version";

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.POST);

            request.AddParameter("dataViewName", "Test");
            request.AddParameter("UserLogin", "JohnS");
            request.AddParameter("Password", "Password@2");


            IRestResponse<EmeraldsSimpleLogin.Root> response = client.Execute<EmeraldsSimpleLogin.Root>(request);
            _authToken = response.Data._accessToken;

            responseResult = "";
            if (response.IsSuccessful)
            {
                responseResult = response.Content.ToString();
            }
            else
            {
                responseResult = response.ErrorMessage;
            }

            // Console.WriteLine(responseResult);
        }

        public List<string> findFromAPI(string responseResult)
        {
            // deserialize api
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject(responseResult);

            return null;
        }

        #region Get titles and definitions

        public void GetAudiences(string count = "1000")
        {
            /* Once authorised, ask API for list of audiences
             * Find correct endpoint
             * Set up correct endpoint here
             * Add authorisation header
             * Add any parameters
             * Get response from api
             * Pour response into class
             * Iterate through class to get audience names
             * Add names to list
             * Console out each name
             * */

            var url = string.Join("/", _baseUrl, $"Test/Audiences?count={count}");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            audienceListResponse = client.Execute<EmeraldsAudiences.Root>(request);
            // _authToken = response.Data.accessToken;

            // putAudiencesInList(audienceListResponse);
        }


        public List<string> putAudiencesInList(IRestResponse<EmeraldsAudiences.Root> audList)
        {
            List<string> audienceTitles = new List<string>();
            foreach (var item in audienceListResponse.Data.list)

            {
                var title = item.title;
                audienceTitles.Add(title);

                //Console.WriteLine("----------------------------------------------------------------");
                //string firstName = item.owner.firstname;
                //Console.WriteLine(firstName);
                //string surName = item.owner.surname;
                //Console.WriteLine(surName);
                //string username = item.owner.username;
                //Console.WriteLine(username);
                //int id = item.owner.id;
                //Console.WriteLine(id);
                //string emailAdress = item.owner.emailAddress;
                //Console.WriteLine(emailAdress);
            }
            // Loop through audience titles and print each item
            // Actually print the list

            foreach (var title in audienceTitles)
            {
                Console.WriteLine("Audience Title: " + title);
            }
            return audienceTitles;
    }

        public void GetDashboards(string count = "100")
        {
            var url = string.Join("/", _baseUrl, $"Test/Users/JSmith/Dashboards?count={count}");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsDashboards.Root> response = client.Execute<EmeraldsDashboards.Root>(request);
            dashboardTitles = new List<string>();

            foreach (var item in response.Data.list)

            {
                var title = item.title;
                dashboardTitles.Add(title);
            }
            // Loop through  titles and print each item
            foreach (var title in dashboardTitles)
            {
                Console.WriteLine("Dashboard Title: " + title);
            }
        }

        public void GetCollections(string count = "50")
        {
            var url = string.Join("/", _baseUrl, $"Test/Collections?count={count}");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsCollections.Root> response = client.Execute<EmeraldsCollections.Root>(request);

            collectionTitles = new List<string>();

            foreach (var item in response.Data.list)
            {
                var title = item.title;
                collectionTitles.Add(title);
            }
            // Loop through collection titles and print each item
            foreach (var title in collectionTitles)
            {
                Console.WriteLine("Collection Title: " + title);
            }
        }

        public void GetCompositions(string count = "100")
        {
            var url = string.Join("/", _baseUrl, $"Test/AudienceCompositions?count={count}");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsCompositions.Root> response = client.Execute<EmeraldsCompositions.Root>(request);

            compositionDescriptions = new List<string>();

            foreach (var item in response.Data.list)
            {
                var description = item.description;
                compositionDescriptions.Add(description);
            }
            // Loop through collection titles and print each item
            foreach (var description in compositionDescriptions)
            {
                Console.WriteLine("Audience Composition Description: " + description);
            }
        }

        public void GetCampaigns(string count = "100")
        {
            var url = string.Join("/", _baseUrl, $"Test/PeopleStage/Test/Elements?count={count}");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsCampaigns.Root> response = client.Execute<EmeraldsCampaigns.Root>(request);

            campaignDescriptions = new List<string>();

            foreach (var item in response.Data.list)

            {
                var description = item.description;
                campaignDescriptions.Add(description);
            }
            // Loop through collection titles and print each item
            foreach (var description in campaignDescriptions)
            {
                Console.WriteLine("Campaign Description: " + description);
            }
        }

        #endregion Get titles and definitions

        #region Getting specific Audience

        public string PickAudience(IRestResponse<EmeraldsAudiences.Root> responseAudience, string chooseNameOrId)
        {
            string gotId = "";
            string gotTitle = "";
            int userGaveAnInt = 0;

            // Get Key value pairs with the audience ids and titles
            List<KeyValuePair<string, string>> audienceData = new List<KeyValuePair<string, string>>();
            foreach (var item in responseAudience.Data.list)
            {
                gotId = item.id.ToString();
                gotTitle = item.title;
                audienceData.Add(new KeyValuePair<string, string>(gotId, gotTitle));
            }

            // Handle input
            bool isUserInputAInt = int.TryParse(chooseNameOrId, out userGaveAnInt);
            if (isUserInputAInt == true)
            {
                // If user has input a number, try to match with an ID from a row in the list
                // If the number is a hit as an ID proceed to get the definition from the audience ID
                var result = audienceData.Find(x => x.Key == chooseNameOrId);

                returnAudID = result.Key;
                Console.WriteLine($"Matching Audience ID found = {returnAudID}");

                if (returnAudID == null)
                {
                    // If no hits, error message and loop to try again or break
                    Console.WriteLine("No matching ID found");
                }
            }
            else
            {
                // If user has input a string, try to match string with the first row in the list that has the correct name
                // If name and ID is a hit, then proceed to get definition
                var result = audienceData.Find(x => x.Value.ToLower() == chooseNameOrId.ToLower());

                returnAudID = result.Key;

                if (returnAudID == null)
                {
                    // If no hits, error or break
                    Console.WriteLine("No matching Audience name found");
                }
                else
                {
                    Console.WriteLine($"Matching Audience ID found = {returnAudID}");
                }
            }
            // Return ID to pass into another method
            return returnAudID;
        }

        public string GetAudienceDefinition(string audienceId)
        {
            var url = string.Join("/", _baseUrl, "Test/Audiences", audienceId);
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<AudienceDetails.Root> audienceDetails = client.Execute<AudienceDetails.Root>(request);

            audienceDefinition = audienceDetails.Content;

            return audienceDefinition;
        }

        public void AudJsonSave(string audienceDefinition)
        {
            string filelocation = @"C:\Users\temp\audience.json";

            File.WriteAllText(filelocation, audienceDefinition);

            // Talk to user
            Console.WriteLine("Audience definition successfully saved to file");

            // Console.ReadLine();
        }

        #endregion Getting specific Audience

        #region Post to Audience

        public AudienceDetails.Root GetAudJsonFromFile()
        {
            string audienceJson = File.ReadAllText(@"C:\Users\temp\audience.json");

            singleAudience = JsonConvert.DeserializeObject<AudienceDetails.Root>(audienceDefinition);

            return singleAudience;
        }

        public AudienceDetails.Root ChangeAudienceTitle1(AudienceDetails.Root currentAudience, string newAudienceTitle = "Renamed Audience")
        {
            // Assign new name to current audience.title
            currentAudience.title = newAudienceTitle;
            return currentAudience;
        }

        public string JsonFromAudience(AudienceDetails.Root audienceObject)
        {
            var result = JsonConvert.SerializeObject(audienceObject, Formatting.Indented);
            return result;
        }

        [Obsolete]
        public string PostToAudience(string json)
        {
            var url = string.Join("/", _baseUrl, "Test/Audiences");

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest(RestSharp.Method.POST);

            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            request.AddBody(json);

            var response = client.Execute(request);

            string apiResultUrl = response.Headers[2].Value.ToString();
            string urlSubstring = apiResultUrl.Substring(53);
            string resultUrl = string.Join("/", "https://cloudtest.faststats.co.uk/Test/Orbit/en/", urlSubstring);

            Console.WriteLine($"The link for your new Audience is: {resultUrl}");
            Console.ReadLine();

            return resultUrl;
        }

        #endregion Post to Audience

        #region Getting specific Dashboard

        public string PickDashboard(string dashboardInput)
        {
            var url = string.Join("/", _baseUrl, "Test/Users/JSmith/Dashboards?count=1000&doSystemLookup=false");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsDashboards.Root> responseDashboard = client.Execute<EmeraldsDashboards.Root>(request);

            string gotId = "";
            string gotTitle = "";
            int userGaveAnInt = 0;

            // Get Key value pairs with the audience ids and titles
            List<KeyValuePair<string, string>> dashboardData = new List<KeyValuePair<string, string>>();
            foreach (var item in responseDashboard.Data.list)
            {
                gotId = item.id.ToString();
                gotTitle = item.title;
                dashboardData.Add(new KeyValuePair<string, string>(gotId, gotTitle));
            }

            Console.WriteLine("Request a specific Dashboard by name or ID by changing input in Program");
            Console.WriteLine("Press Enter when ready to continue...");
            Console.ReadLine();

            // Handle input
            bool isUserInputAInt = int.TryParse(dashboardInput, out userGaveAnInt);
            if (isUserInputAInt == true)
            {
                // If user has input a number, try to match with an ID from a row in the list
                // If the number is a hit as an ID proceed to get the definition from the audience ID
                var result = dashboardData.Find(x => x.Key == dashboardInput);

                returnDashID = result.Key;
                Console.WriteLine($"Matching Dashboard ID found = {returnDashID}");

                if (returnDashID == null)
                {
                    // If no hits, error message and loop to try again or break
                    Console.WriteLine("No matching ID found");
                }
            }
            else
            {
                // If user has input a string, try to match string with the first row in the list that has the correct name
                // If name and ID is a hit, then proceed to get definition
                var result = dashboardData.Find(x => x.Value.ToLower() == dashboardInput.ToLower());

                returnDashID = result.Key;

                if (returnDashID == null)
                {
                    // If no hits, error or break
                    Console.WriteLine("No matching Dashboard name found");
                }
                else
                {
                    Console.WriteLine($"Matching ID found = {returnDashID}");
                }
            }
            // Return ID to pass into another method
            Console.ReadLine();
            return returnDashID;
        }

        public string GetDashboardDefinition(string dashboardId)
        {
            var url = string.Join("/", _baseUrl, "Test/Users/JohnS/Dashboards", dashboardId);
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<GetDashboard.Root> dashboardDetails = client.Execute<GetDashboard.Root>(request);

            dashboardDefinition = dashboardDetails.Content;

            return dashboardDefinition;
        }

        public void ConvertDashToJsonAndSave(string dashboardDefinition)
        {
            string filelocation = @"C:\Users\temp\dashboard.json";

            File.WriteAllText(filelocation, dashboardDefinition);

            // Talk to user
            Console.WriteLine("Dashboard definition successfully saved to file");

            Console.ReadLine();
        }

        #endregion Getting specific Dashboard

        #region Post to Dashboard

        public DashboardDetails.Root GetDashJsonFromFile()
        {
            string dashboardJson = File.ReadAllText(@"C:\Users\temp\dashboard.json");

            var singleDashboard = JsonConvert.DeserializeObject<DashboardDetails.Root>(dashboardJson);

            return singleDashboard;
        }

        public DashboardDetails.Root ChangeDashboardTitle(DashboardDetails.Root currentDashboard, string newDashboardTitle = "Renamed Dashboard")
        {
            // Assign new name to current audience.title
            currentDashboard.title = newDashboardTitle;

            return currentDashboard;
        }

        public string JsonFromDashboard(DashboardDetails.Root dashboardObject)
        {
            var result1 = JsonConvert.SerializeObject(dashboardObject);

            string filelocation = @"C:\Users\temp\dashboardNewTitle.json";

            File.WriteAllText(filelocation, result1);

            string result = File.ReadAllText(@"C:\Users\temp\dashboardNewTitle.json");

            return result;
        }

        public string PostToDashboard(string json)
        {
            var url = string.Join("/", _baseUrl, "Test/Dashboards");

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.POST);

            request.AddHeader("Authorization", $"Bearer {_authToken}");
            request.AddHeader("content-type", "application/json");
            // request.AddHeader("Content-Type", "charset=UTF-8");
            // request.AddJsonBody(json);
            request.AddParameter("dashboardDetail", json, ParameterType.RequestBody);

            // IRestResponse response = client.Execute(request);

            IRestResponse<DashboardDetails.Root> response = client.Execute<DashboardDetails.Root>(request);

            // var responseIntoClass = JsonConvert.DeserializeObject<DashboardDetails.Root>(response.Content);

            string apiResultUrl = response.Headers[2].Value.ToString();
            string urlSubstring = apiResultUrl.Substring(40);
            string resultUrl = string.Join("/", "https://cloudtest.faststats.co.uk/Test/Orbit/en/", urlSubstring);

            Console.WriteLine($"The link for your new Dashboard is: {resultUrl}");
            Console.ReadLine();

            return resultUrl;
        }

        public void GetSingleDashboard()
        {
            Console.WriteLine("Hi Everyone");
            var url = string.Join("/", _baseUrl, "Test/Users/JohnS/Dashboards/3");
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            IRestResponse<EmeraldsDashboards.Root> response = client.Execute<EmeraldsDashboards.Root>(request);
            var responseResult = "";
            if (response.IsSuccessful)
            {
                responseResult = response.Content;
            }
            else
            {
                responseResult = response.ErrorMessage;
            }
            try
            {
                string fullPath = @"C:\Users\temp\dashboard.json";
                File.WriteAllText(fullPath, string.Empty);
                File.WriteAllText(fullPath, responseResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            ReadAllDashboardData();
        }

        private void ReadAllDashboardData()
        {
            string fullPath = @"C:\Users\temp\dashboard.json";
            var DashboardJSON = File.ReadAllText(fullPath);
            DeserializeDashboardObject(DashboardJSON);
        }

        private void DeserializeDashboardObject(string dashboardJson)
        {
            var dashboard = JsonConvert.DeserializeObject<DashboardDetails.Root>(dashboardJson);
            dashboard.title = " Thank you Melody!! (release testing 1.9.11)";
            SerializeDashboardObject(dashboard);
        }

        private void SerializeDashboardObject(DashboardDetails.Root dashboard)
        {
            string NewDashboardJsonData = JsonConvert.SerializeObject(dashboard);
            try
            {
                string newDashboardFullPath = @"C:\Users\temp\dashboard.json";
                File.WriteAllText(newDashboardFullPath, string.Empty);
                File.WriteAllText(newDashboardFullPath, NewDashboardJsonData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            CreateDashboardAPI(NewDashboardJsonData);
        }

        private void CreateDashboardAPI(string NewDashboardJsonData)
        {
            var url = string.Join("/", _baseUrl, "Test/Dashboards");
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.POST);
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            request.AddParameter("dashboardDetail", NewDashboardJsonData, ParameterType.RequestBody);
            request.AddHeader("content-type", "application/json");
            IRestResponse<DashboardDetails.Root> response = client.Execute<DashboardDetails.Root>(request);
            var location = response.Headers[2];
            Console.WriteLine(location);
            var responseResult = "";
            if (response.IsSuccessful)
            {
                responseResult = response.Content;
            }
            else
            {
                responseResult = response.ErrorMessage;
            }
            Console.WriteLine("You have successfully created a new dashboard");
        }

        #endregion Post to Dashboard

        #region Getting specific Collection

        public string PickCollection(string collectionInput)
        {
            var url = string.Join("/", _baseUrl, "Test/Collections?count=1000");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsCollections.Root> responseCollection = client.Execute<EmeraldsCollections.Root>(request);

            string gotId = "";
            string gotTitle = "";
            int userGaveAnInt = 0;

            // Get Key value pairs with the ids and titles
            List<KeyValuePair<string, string>> collectionData = new List<KeyValuePair<string, string>>();
            foreach (var item in responseCollection.Data.list)
            {
                gotId = item.id.ToString();
                gotTitle = item.title;
                collectionData.Add(new KeyValuePair<string, string>(gotId, gotTitle));
            }

            Console.WriteLine("Request a specific Collection by name or ID by changing input in Program");
            Console.WriteLine("Press Enter when ready to continue...");
            Console.ReadLine();

            // Handle input
            bool isUserInputAInt = int.TryParse(collectionInput, out userGaveAnInt);
            if (isUserInputAInt == true)
            {
                // If user has input a number, try to match with an ID from a row in the list
                // If the number is a hit as an ID proceed to get the definition from the audience ID
                var result = collectionData.Find(x => x.Key == collectionInput);

                returnCollID = result.Key;
                Console.WriteLine($"Matching Collection ID found = {returnCollID}");

                if (returnCollID == null)
                {
                    // If no hits, error message and loop to try again or break
                    Console.WriteLine("No matching ID found");
                }
            }
            else
            {
                // If user has input a string, try to match string with the first row in the list that has the correct name
                // If name and ID is a hit, then proceed to get definition
                var result = collectionData.Find(x => x.Value.ToLower() == collectionInput.ToLower());

                returnCollID = result.Key;

                if (returnCollID == null)
                {
                    // If no hits, error or break
                    Console.WriteLine("No matching Collection name found");
                }
                else
                {
                    Console.WriteLine($"Matching ID found = {returnCollID}");
                }
            }
            // Return ID to pass into another method
            Console.ReadLine();
            return returnCollID;
        }

        public string GetCollectionDefinition(string collectionId)
        {
            var url = string.Join("/", _baseUrl, "Test/Collections", collectionId);
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<CollectionDetails.Root> collectionDetails = client.Execute<CollectionDetails.Root>(request);

            collectionDefinition = collectionDetails.Content;

            return collectionDefinition;
        }

        public void ConvertCollToJsonAndSave(string collectionDefinition)
        {
            string filelocation = @"C:\Users\temp\collection.json";

            File.WriteAllText(filelocation, collectionDefinition);

            // Talk to user
            Console.WriteLine("Collection definition successfully saved to file");

            Console.ReadLine();
        }

        public CollectionDetails.Root GetCollJsonFromFile()
        {
            string collectionJson = File.ReadAllText(@"C:\Users\temp\collection.json");

            singleCollection = JsonConvert.DeserializeObject<CollectionDetails.Root>(collectionDefinition);

            return singleCollection;
        }

        public CollectionDetails.Root ChangeCollectionTitle(CollectionDetails.Root currentCollection, string newCollectionTitle = "Renamed Audience")
        {
            // Assign new name to current audience.title
            currentCollection.title = newCollectionTitle;
            return currentCollection;
        }

        public string JsonFromCollection(CollectionDetails.Root collectionObject)
        {
            var result = JsonConvert.SerializeObject(collectionObject, Formatting.Indented);
            return result;
        }

        [Obsolete]
        public string PostToCollection(string json)
        {
            var url = string.Join("/", _baseUrl, "Test/Collections");

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest(RestSharp.Method.POST);

            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            request.AddBody(json);

            var response = client.Execute(request);

            string apiResultUrl = response.Headers[2].Value.ToString();
            string urlSubstring = apiResultUrl.Substring(53);
            string resultUrl = string.Join("/", "https://cloudtest.faststats.co.uk/Test/Orbit/en", urlSubstring.ToLower());

            Console.WriteLine($"The link for your new Collection is: {resultUrl}");
            Console.ReadLine();

            return resultUrl;
        }

        #endregion Getting specific Collection

        #region Getting specific Composition

        public string PickComposition(string compositionInput)
        {
            var url = string.Join("/", _baseUrl, "Test/AudienceCompositions?count=1000");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsCompositions.Root> responseComposition = client.Execute<EmeraldsCompositions.Root>(request);

            string gotId = "";
            string gotDescription = "";
            int userGaveAnInt = 0;

            // Get Key value pairs with the ids and titles
            List<KeyValuePair<string, string>> compositionData = new List<KeyValuePair<string, string>>();
            foreach (var item in responseComposition.Data.list)
            {
                gotId = item.id.ToString();
                gotDescription = item.description;
                compositionData.Add(new KeyValuePair<string, string>(gotId, gotDescription));
            }

            Console.WriteLine("Request a specific Campaign by description or ID by changing input in Program");
            Console.WriteLine("Press Enter when ready to continue...");
            Console.ReadLine();

            // Handle input
            bool isUserInputAInt = int.TryParse(compositionInput, out userGaveAnInt);
            if (isUserInputAInt == true)
            {
                // If user has input a number, try to match with an ID from a row in the list
                // If the number is a hit as an ID proceed to get the definition from the ID
                var result = compositionData.Find(x => x.Key == compositionInput);

                returnCompID = result.Key;
                Console.WriteLine($"Matching Composition ID found = {returnCompID}");

                if (returnCompID == null)
                {
                    // If no hits, error message and loop to try again or break
                    Console.WriteLine("No matching ID found");
                }
            }
            else
            {
                // If user has input a string, try to match string with the first row in the list that has the correct name
                // If name and ID is a hit, then proceed to get definition
                var result = compositionData.Find(x => x.Value.ToLower() == compositionInput.ToLower());

                returnCompID = result.Key;

                if (returnCompID == null)
                {
                    // If no hits, error or break
                    Console.WriteLine("No matching Composition name found");
                }
                else
                {
                    Console.WriteLine($"Matching ID found = {returnCompID}");
                }
            }
            // Return ID to pass into another method
            Console.ReadLine();
            return returnCompID;
        }

        public string GetCompositionDefinition(string compositionId)
        {
            var url = string.Join("/", _baseUrl, "Test/AudienceCompositions/Test", compositionId);
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<CompositionDetails.Root> compositionDetails = client.Execute<CompositionDetails.Root>(request);

            compositionDefinition = compositionDetails.Content;

            return compositionDefinition;
        }

        public void ConvertCompToJsonAndSave(string audienceDefinition)
        {
            string filelocation = @"C:\Users\temp\composition.json";

            File.WriteAllText(filelocation, compositionDefinition);

            // Talk to user
            Console.WriteLine("Composition definition successfully saved to file");

            Console.ReadLine();
        }

        #endregion Getting specific Composition

        #region Post to Composition

        public CompositionDetails.Root GetCompJsonFromFile()
        {
            string compositionJson = File.ReadAllText(@"C:\Users\temp\composition.json");

            singleComposition = JsonConvert.DeserializeObject<CompositionDetails.Root>(compositionDefinition);

            return singleComposition;
        }

        public CompositionDetails.Root ChangeCompositionTitle(CompositionDetails.Root currentComposition, string newCompositionTitle = "Renamed Composition")
        {
            // Assign new name to current audience.title
            currentComposition.description = newCompositionTitle;
            return currentComposition;
        }

        public string JsonFromComposition(CompositionDetails.Root compositionObject)
        {
            var result = JsonConvert.SerializeObject(compositionObject, Formatting.Indented);
            return result;
        }

        [Obsolete]
        public string PostToComposition(string json)
        {
            var url = string.Join("/", _baseUrl, "Test/AudienceCompositions/Test");

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest(RestSharp.Method.POST);

            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            request.AddBody(json);

            var response = client.Execute(request);

            string apiResultUrl = response.Headers[2].Value.ToString();
            string urlSubstring = apiResultUrl.Substring(79);

            string resultUrl = string.Join("/", "https://cloudtest.faststats.co.uk/Test/Orbit/en/audiences/compositions", urlSubstring);

            Console.WriteLine($"The link for your new Composition is: {resultUrl}");
            Console.ReadLine();

            return resultUrl;
        }

        #endregion Post to Composition

        #region Getting specific Campaign

        public string PickCampaign(string campaignInput)
        {
            var url = string.Join("/", _baseUrl, "Test/PeopleStage/Test/Elements?count=1000");
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<EmeraldsCampaigns.Root> responseCampaign = client.Execute<EmeraldsCampaigns.Root>(request);

            string gotId = "";
            string gotDescription = "";
            int userGaveAnInt = 0;

            // Get Key value pairs with the ids and titles
            List<KeyValuePair<string, string>> campaignData = new List<KeyValuePair<string, string>>();
            foreach (var item in responseCampaign.Data.list)
            {
                gotId = item.id.ToString();
                gotDescription = item.description;
                campaignData.Add(new KeyValuePair<string, string>(gotId, gotDescription));
            }

            Console.WriteLine("Request a specific Campaign by description or ID by changing input in Program");
            Console.WriteLine("Press Enter when ready to continue...");
            Console.ReadLine();

            // Handle input
            bool isUserInputAInt = int.TryParse(campaignInput, out userGaveAnInt);
            if (isUserInputAInt == true)
            {
                // If user has input a number, try to match with an ID from a row in the list
                // If the number is a hit as an ID proceed to get the definition from the ID
                var result = campaignData.Find(x => x.Key == campaignInput);

                returnCampID = result.Key;
                Console.WriteLine($"Matching Campaign ID found = {returnCampID}");

                if (returnCampID == null)
                {
                    // If no hits, error message and loop to try again or break
                    Console.WriteLine("No matching ID found");
                }
            }
            else
            {
                // If user has input a string, try to match string with the first row in the list that has the correct name
                // If name and ID is a hit, then proceed to get definition
                var result = campaignData.Find(x => x.Value.ToLower() == campaignInput.ToLower());

                returnCampID = result.Key;

                if (returnCampID == null)
                {
                    // If no hits, error or break
                    Console.WriteLine("No matching Campaign name found");
                }
                else
                {
                    Console.WriteLine($"Matching ID found = {returnCampID}");
                }
            }
            // Return ID to pass into another method
            Console.ReadLine();
            return returnCampID;
        }

        public string GetCampaignDefinition(string campaignId)
        {
            var url = string.Join("/", _baseUrl, "Test/PeopleStage/Test/Elements", campaignId);
            // Call the version endpoint of the orbit API

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authToken}");

            IRestResponse<CampaignDetails.Root> campaignDetails = client.Execute<CampaignDetails.Root>(request);

            campaignDefinition = campaignDetails.Content;

            return campaignDefinition;
        }

        public void ConvertCampToJsonAndSave(string campaignDefinition)
        {
            string filelocation = @"C:\Users\temp\campaign.json";

            File.WriteAllText(filelocation, campaignDefinition);

            // Talk to user
            Console.WriteLine("Campaign definition successfully saved to file");

            Console.ReadLine();
        }

        #endregion Getting specific Campaign

        #region Post to Campaign

        public CampaignDetails.Root GetCampJsonFromFile()
        {
            string campaignJson = File.ReadAllText(@"C:\Users\temp\campaign.json");

            singleCampaign = JsonConvert.DeserializeObject<CampaignDetails.Root>(campaignJson);

            return singleCampaign;
        }

        public CampaignDetails.Root ChangeCampaignTitle(CampaignDetails.Root currentCampaign, string newCampaignTitle = "Renamed Campaign")
        {
            // Assign new name to current audience.title
            currentCampaign.description = newCampaignTitle;
            return currentCampaign;
        }

        public string JsonFromCampaign(CampaignDetails.Root campaignObject)
        {
            var result = JsonConvert.SerializeObject(campaignObject, Formatting.Indented);
            return result;
        }

        [Obsolete]
        public string PostToCampaign(string json, string campaignId)
        {
            var url = string.Join("/", _baseUrl, "Test/PeopleStage/Test/Elements", campaignId, "PublishJobs");

            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest(RestSharp.Method.POST);

            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Authorization", $"Bearer {_authToken}");
            request.AddBody(json);

            var response = client.Execute(request);

            string apiResultUrl = response.Headers[2].Value.ToString();
            string urlSubstring = apiResultUrl.Substring(53);
            string resultUrl = string.Join("/", "https://cloudtest.faststats.co.uk/Test/Orbit/en", urlSubstring);

            Console.WriteLine($"The link for your new Campaign is: {resultUrl}");
            Console.ReadLine();

            return resultUrl;
        }

        #endregion Post to Campaign
    }
}