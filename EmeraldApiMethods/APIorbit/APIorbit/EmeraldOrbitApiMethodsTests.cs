using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using EFCore1;
using EFCore1.DBContext;
using GroupApi.EmeraldApiMethods.ConsoleApp1.ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroupApi
{
    [TestClass]
    public class EmeraldOrbitApiMethodsTests
    {
        private Stopwatch _stopw = new Stopwatch();
        private EmeraldRestAPIMethods _eApi = new EmeraldRestAPIMethods("https://cloudtest.faststats.co.uk/Test/OrbitAPI");
        private EmeraldTestMethodHelper _eHelper = new EmeraldTestMethodHelper();
        private DBHelper _dbHelper = new DBHelper();
        Emerald1Context context = new Emerald1Context();
        string noTime = "n/a";

        //time getting an authtoken

        #region Testing does it get what we want?
        #region Authtoken tests

        [TestMethod]
        public void GetAuthTokenTest()
        {
            _stopw.Start();

            # region Get AuthToken
            _eApi.GetAuthToken();
            var foundAuthToken = _eApi._authToken;

            bool resultOfTest = false; // false as a default
            if (foundAuthToken != "")
            {
                resultOfTest = true; //because our authtoken isn't blank
            }
            #endregion Get AuthToken

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest);//if resultOfTest is true, this passes!
        }

        //[TestMethod]
        //public void GetAuthTokenMultipleTest()
        //{
        //    int numberOfAuth = 10;
        //    _stopw.Start();

        //    bool resultOfTest = false;

        //    #region Get AuthToken
        //    for (int i = 0; i < numberOfAuth; i++)
        //    {
        //        _eApi.GetAuthToken();
        //        var foundAuthToken = _eApi._authToken;

        //        if (foundAuthToken != "")
        //        {
        //           resultOfTest = true; //because our authtoken isn't blank
        //        }
                
        //        else if (foundAuthToken == null)
        //        {
        //            resultOfTest = false;
        //        }
        //    }
           
        //    #endregion Get AuthToken

        //    _stopw.Stop();

        //    string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        //    _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
        //    Assert.IsTrue(resultOfTest);//if resultOfTest is true, this passes!
        //}
        #endregion Authtoken tests

        [TestMethod]
        public void GetAudiencesTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get AudienceList

            _eApi.GetAudiences();

            bool resultOfTest = false; // false as a default 
            if (_eApi.audienceListResponse.Data != null)
            {
                if (_eApi.audienceListResponse.Data.list.Count > 0)
                {
                    resultOfTest = true;
                }
            }

            #endregion Get AudienceList

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetAudienceAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get AudienceList

            _eApi.GetAudiences();
            var audList = _eApi.putAudiencesInList(_eApi.audienceListResponse);

            bool resultOfTest = false; // false as a default
            if (audList.Count > 0)
            {
                resultOfTest = true;
            }
            #endregion Get AudienceList

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetDashboardAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Dashboard List

            _eApi.GetDashboards();

            bool resultOfTest = false; // false as a default
            if (_eApi.dashboardTitles.Count > 0)
            {
                resultOfTest = true;
            }
            #endregion Get Dashboard List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetCollectionAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Collection List

            _eApi.GetCollections();

            bool resultOfTest = false; // false as a default
            if (_eApi.collectionTitles.Count > 0)
            {
                resultOfTest = true;
            }
            #endregion Get Collection List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetCompositionsAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Composition List

            _eApi.GetCompositions();

            bool resultOfTest = false; // false as a default
            if (_eApi.compositionDescriptions.Count > 0)
            {
                resultOfTest = true;
            }
            #endregion Get Composition List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetCampaignsAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Campaigns List

            _eApi.GetCampaigns();

            bool resultOfTest = false; // false as a default
            if (_eApi.campaignDescriptions.Count > 0)
            {
                resultOfTest = true;
            }
            #endregion Get Campaigns List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        #endregion Testing does it get what we want?

        #region Audience tests
        [TestMethod]
        public void CheckValidIDAudienceTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetAudiences();

            _eApi.PickAudience(_eApi.audienceListResponse, "3");

            bool resultOfTest;
            if (_eApi.returnAudID == "3")
            {
                resultOfTest = true; 
            }
            else
            {
                resultOfTest = false;
            }

            string noTime = "n/a";
            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void CheckValidNameAudienceTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetAudiences();

            _eApi.PickAudience(_eApi.audienceListResponse, "Men in Warwick");

            bool resultOfTest;
            if (_eApi.returnAudID == "5")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }


        [TestMethod]
        public void GetAudienceDefinitionTest()
        {
            _eApi.GetAuthToken();

            #region Get Single Audience Definition

            _eApi.GetAudienceDefinition("5");

            bool resultOfTest = false; // false as a default
            if (_eApi.audienceDefinition != null)
            {
                resultOfTest = true;
            }
            #endregion Get Single Audience Definition


            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        [Obsolete]
        public void PostToAudienceTest()
        {
            _eApi.GetAuthToken();

            //_eApi.GetAudiences();
            //_eApi.PickAudience(_eApi.audienceListResponse, audienceNameOrID);
            _eApi.GetAudienceDefinition("1154");
            _eApi.AudJsonSave(_eApi.audienceDefinition);

            var jsonFromFile = _eApi.GetAudJsonFromFile();
            var newTitleJson = _eApi.ChangeAudienceTitle1(jsonFromFile, "Renamed Audience");
            string json =_eApi.JsonFromAudience(newTitleJson);

            _stopw.Start();

            #region Post to Audience
            _eApi.PostToAudience(json);

            bool resultOfTest = false; // false as a default
            if (_eApi.dataPosted != null)
            {
                resultOfTest = true;
            }
            #endregion Get Post to Audience

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

           _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }


        #endregion Audience tests

        #region Dashboard tests
        [TestMethod]
        public void CheckValidIDDashboardTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetDashboards();

            _eApi.PickDashboard(_eApi.dashboardListResponse, "3");

            bool resultOfTest;
            if (_eApi.returnDashID == "3")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

           _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void CheckValidNameDashboardTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetDashboards();

            _eApi.PickDashboard(_eApi.dashboardListResponse, "Test JS2");

            bool resultOfTest;
            if (_eApi.returnDashID == "3")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetDashboardDefinitionTest()
        {
            _eApi.GetAuthToken();

            #region Get Single Dasboard Definition

            _eApi.GetDashboardDefinition("3");

            bool resultOfTest = false; // false as a default
            if (_eApi.dashboardDefinition != null)
            {
                resultOfTest = true;
            }
            #endregion Get Single Dasboard Definition

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        [Obsolete]
        public void PostToDashboardTest()
        {
            _eApi.GetAuthToken();

            _eApi.GetDashboardDefinition("3");
            _eApi.DashJsonSave(_eApi.dashboardDefinition);

            var jsonFromFile = _eApi.GetDashJsonFromFile();
            var newTitleJson = _eApi.ChangeDashboardTitle(jsonFromFile, "New Dash Name");
            string json = _eApi.JsonFromDashboard(newTitleJson);

            _stopw.Start();

            #region Post to Dashboard
            _eApi.PostToDashboard(json);

            bool resultOfTest = false; // false as a default
            if (_eApi.dataPosted != null)
            {
                resultOfTest = true;
            }
            #endregion Post to Dashboard

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }


        #endregion Dashboard tests

        #region Collection tests
        [TestMethod]
        public void CheckValidIDCollectionTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetCollections();

            _eApi.PickCollection(_eApi.collectionListResponse, "122");

            bool resultOfTest;
            if (_eApi.returnCollID == "122")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

           _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void CheckValidNameCollectionTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetCollections();

            _eApi.PickCollection(_eApi.collectionListResponse, "2.1) One dimensional charts of Postal Area");

            bool resultOfTest;
            if (_eApi.returnCollID == "122")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void GetCollectionDefinitionTest()
        {
            _eApi.GetAuthToken();

            #region Get Single Collection Definition

            _eApi.GetCollectionDefinition("3");

            bool resultOfTest = false; // false as a default
            if (_eApi.collectionDefinition != null)
            {
                resultOfTest = true;
            }
            #endregion Get Single Collection Definition

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        [Obsolete]
        public void PostToCollectionsTest()
        {
            _eApi.GetAuthToken();

            _eApi.GetCollectionDefinition("122");
            _eApi.CollJsonSave(_eApi.collectionDefinition);

            var jsonFromFile = _eApi.GetCollJsonFromFile();
            var newTitleJson = _eApi.ChangeCollectionTitle(jsonFromFile, "New Collection Name");
            string json = _eApi.JsonFromCollection(newTitleJson);

            _stopw.Start();

            #region Post to Collection
            _eApi.PostToCollection(json);

            bool resultOfTest = false; // false as a default
            if (_eApi.dataPosted != null)
            {
                resultOfTest = true;
            }
            #endregion Post to Collection

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

           _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }


        #endregion Collection tests

        #region Composition tests
        [TestMethod]
        public void CheckValidIDCompositionTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetCompositions();

            _eApi.PickComposition(_eApi.compositionListResponse, "129");

            bool resultOfTest;
            if (_eApi.returnCompID == "129")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void CheckValidNameCompositionTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetCompositions();

            _eApi.PickComposition(_eApi.compositionListResponse, "Wibbles");

            bool resultOfTest;
            if (_eApi.returnCompID == "129")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultoftest is true, this passes!
        }

        [TestMethod]
        public void GetCompositionDefinitionTest()
        {
            _eApi.GetAuthToken();

            #region Get Single Composition Definition

            _eApi.GetCompositionDefinition("129");

            bool resultOfTest = false; // false as a default
            if (_eApi.compositionDefinition != null)
            {
                resultOfTest = true;
            }
            #endregion Get Single Composition Definition

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        [Obsolete]
        public void PostToCompositionsTest()
        {
            _eApi.GetAuthToken();

            _eApi.GetCompositionDefinition("129");
            _eApi.CompJsonSave(_eApi.compositionDefinition);

            var jsonFromFile = _eApi.GetCompJsonFromFile();
            var newTitleJson = _eApi.ChangeCompositionTitle(jsonFromFile, "Hi Howdy");
            string json = _eApi.JsonFromComposition(newTitleJson);

            _stopw.Start();

            #region Post to Composition
            _eApi.PostToComposition(json);

            bool resultOfTest = false; // false as a default
            if (_eApi.dataPosted != null)
            {
                resultOfTest = true;
            }
            #endregion Post to Composition

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, _stopw.Elapsed.ToString(), resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        #endregion Composition tests

        #region Campaigns tests
        [TestMethod]
        public void CheckValidIDCampaignTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetCampaigns();

            _eApi.PickCampaign(_eApi.campaignListResponse, "87e6bd33-48f4-47e5-95f5-d18e4578d8b7");

            bool resultOfTest;
            if (_eApi.returnCampID == "87e6bd33-48f4-47e5-95f5-d18e4578d8b7")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

           _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        [TestMethod]
        public void CheckValidNameCampaignTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetCampaigns();

            _eApi.PickCampaign(_eApi.campaignListResponse, "All the bookings for ladies who have booked a trip to america");

            bool resultOfTest;
            if (_eApi.returnCampID == "87e6bd33-48f4-47e5-95f5-d18e4578d8b7")
            {
                resultOfTest = true;
            }
            else
            {
                resultOfTest = false;
            }

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultoftest is true, this passes!
        }

        [TestMethod]
        public void GetCampaignDefinitionTest()
        {
            _eApi.GetAuthToken();

            #region Get Single Campaign Definition

            _eApi.GetCampaignDefinition("87e6bd33-48f4-47e5-95f5-d18e4578d8b7");

            bool resultOfTest = false; // false as a default
            if (_eApi.campaignDefinition != null)
            {
                resultOfTest = true;
            }
            #endregion Get Single Campaign Definition

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            _dbHelper.AddRowToTests(context, testName, noTime, resultOfTest);
            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
        }

        #endregion Campaigns tests

        #region Tests with time thresholds

        // Get Auth token within threshold time 

        [TestMethod]
        public void GetAuthTokenTimeThresholdTest()
        {
            _stopw.Start();

            #region Get AuthToken

            _eApi.GetAuthToken();

            #endregion Get AuthToken

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(_stopw.Elapsed.TotalMilliseconds <= 10000);//if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, _stopw.Elapsed.TotalMilliseconds <= 10000);
        }

        [TestMethod]
        public void RunATestAndCompare()
        {
            string searchTerm = "GetCollectionAndListTest"; // Change this for different tests

            // var timeTest = GetDashboardAndListTest().TotalSeconds;

            // retrieve from database a list of times of a given test
            // var abc = _dbHelper.selectRow

            double timeAvg = _dbHelper.ReturnAvgTime(context, 10, searchTerm);
            double timeLast = _dbHelper.ReturnLastTime(context, searchTerm);

            bool resultOfTest = false;
            if ((timeLast > timeAvg * 0.9)&(timeLast < timeAvg * 1.1))
            {
                resultOfTest = true;
            }

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!


        }

            #endregion Tests with time thresholds
        }
}