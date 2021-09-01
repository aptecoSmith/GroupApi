using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GroupApi.EmeraldApiMethods.ConsoleApp1.ConsoleApp1
{
    public class EmeraldTestMethodHelper
    {

        public string logFilePath = "";
        public string logPathRoot = @"C:\Users\emera\temp\OrbitTests";

        public void RecordOnFile(string testName, TimeSpan elapsed, bool testResult)
        {
            logFilePath = string.Join(@"\", logPathRoot, testName);
            string record = Environment.NewLine + DateTime.Now + ":  " + testName + ", " +  elapsed.ToString() + ", " + testResult;
            File.AppendAllText(logFilePath, record);
        }

        public int GetNumberInList(List<string> Titles)
        {

        }
    }
}
