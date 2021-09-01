using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
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
        public string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        //time getting an authtoken

        #region Testing does it get what we want?
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

            Assert.IsTrue(resultOfTest);//if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed , resultOfTest);
        }

        [TestMethod]
        public void GetAudiencesTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get AudienceList

            _eApi.GetAudiences();

            bool resultOfTest = false; // false as a default
            if (_eApi.audienceListResponse.Data.list.Count == 1000) 
            {
                resultOfTest = true; 
            }
            #endregion Get AudienceList

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
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
            if (audList.Count == 1000)
            {
                resultOfTest = true;
            }
            #endregion Get AudienceList

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        [TestMethod]
        public void GetDashboardAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Dashboard List

            _eApi.GetDashboards();

            bool resultOfTest = false; // false as a default
            if (_eApi.dashboardTitles.Count == 100)
            {
                resultOfTest = true;
            }
            #endregion Get Dashboard List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        [TestMethod]
        public void GetCollectionAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Collection List

            _eApi.GetCollections();

            bool resultOfTest = false; // false as a default
            if (_eApi.collectionTitles.Count == 50)
            {
                resultOfTest = true;
            }
            #endregion Get Collection List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        [TestMethod]
        public void GetCompositionsAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Composition List

            _eApi.GetCompositions();

            bool resultOfTest = false; // false as a default
            if (_eApi.compositionDescriptions.Count == 100)
            {
                resultOfTest = true;
            }
            #endregion Get Composition List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        [TestMethod]
        public void GetCampaignsAndListTest()
        {
            _eApi.GetAuthToken();
            _stopw.Start();

            #region Get Campaigns List

            _eApi.GetCampaigns();

            bool resultOfTest = false; // false as a default
            if (_eApi.campaignDescriptions.Count == 100)
            {
                resultOfTest = true;
            }
            #endregion Get Campaigns List

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        #endregion Testing does it get what we want?

        #region Audience tests
        [TestMethod]
        public void CheckValidIDAudienceTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetAudiences();

            _stopw.Start();
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
            _stopw.Stop();

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        [TestMethod]
        public void CheckValidNameAudienceTest()
        {
            // Input a valid ID, make sure the returnAudID gives the same ID 
            _eApi.GetAuthToken();
            _eApi.GetAudiences();

            _stopw.Start();
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
            _stopw.Stop();

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest); //if resultOfTest is true, this passes!
            _eHelper.RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }


        #endregion Audience tests


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

        #endregion Tests with time thresholds
    }
}