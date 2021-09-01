using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMethods1
{
    [TestClass]
    public class OrbitApiMethodsTests
    {
        private Stopwatch _stopw = new Stopwatch();
        private OrbitApiMethods _oapi = new OrbitApiMethods();

        private string recordFilePath = @"C:\temp\record.txt";

        private void RecordOnFile(string testName, TimeSpan elapsed, bool testResult)
        {
            string record = Environment.NewLine + testName + "," + _stopw.Elapsed.ToString() + "," + testResult;

            File.AppendAllText(recordFilePath, record);
        }

        //time getting an authtoken
        [TestMethod]
        public void TimedTest()

        {
            _stopw.Start();

            #region execute some kind of thing

            _oapi._ac.GetAuthToken(_oapi._username, _oapi._password);
            var foundAuthToken = _oapi._ac._authToken;

            bool resultOfTest = false; // false as a default
            if (foundAuthToken != "")
            {
                resultOfTest = true; //because our authtoken isn't blank
            }

            #endregion execute some kind of thing

            _stopw.Stop();
            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Assert.IsTrue(resultOfTest);//if resultOfTest is true, this passes!
            RecordOnFile(testName, _stopw.Elapsed, resultOfTest);
        }

        //time getting an authtoken
        [TestMethod]
        public void TimeLimitTest()
        {
            _stopw.Start();

            #region execute api method

            _oapi._ac.GetAuthToken(_oapi._username, _oapi._password);

            #endregion execute api method

            _stopw.Stop();

            string testName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            // I hate wednesdays so much me too I hate weds
            Assert.IsTrue(_stopw.Elapsed.TotalMilliseconds <= 1000);//if resultOfTest is true, this passes!
            RecordOnFile(testName, _stopw.Elapsed, _stopw.Elapsed.TotalMilliseconds <= 1000);
        }
    }
}