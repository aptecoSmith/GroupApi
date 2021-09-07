using EFCore1.DBContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupApi.EmeraldApiMethods.ConsoleApp1.ConsoleApp1
{
    public class EmeraldTestMethodHelper
    {
        
        public string logFilePath = "";
        public string logPathRoot = @"C:\Users\emera\temp\OrbitTests";

        public void RecordOnFile(string testName, TimeSpan elapsed, bool testResult)
        {
            string result = "";
            if (testResult == true)
            {
                result = "Passed";
            }
            else
            {
                result = "Failed";
            }
            logFilePath = string.Join(@"\", logPathRoot, testName+ ".txt");
            string record = Environment.NewLine + DateTime.Now + ":  " + testName + ", " +  elapsed.ToString() + ", " + result;
            File.AppendAllText(logFilePath, record);
        }


        public List<GroupApi.Test> Return10RowResults(Emerald1Context context, string searchTerm = "GetDashboardAndListTest")
        {
            // What do we think we'll be returning 
            // What is our result
            GroupApi.Test resultFromDB = new GroupApi.Test();
            List<GroupApi.Test> listOfResults = new List<GroupApi.Test>();


            // execute query for database
            var multipleResults = context.TestLog.Where(col => col.NameOfTest == searchTerm);

            foreach (var row in multipleResults)
            {
                if (!listOfResults.Contains(row))
                {
                    listOfResults.Add(row);

                    var time = row.TimeTaken;
                }
            }
            listOfResults.Skip(Math.Max(0, listOfResults.Count() - 10));
            return listOfResults;
        }
    }
}
