using EFCore1.DBContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace EFCore1
{
    public class DBHelper
    {
        // The connection string is the phone number for your database
        public string _conn = "server=localhost;database=Emerald1;UserID=root;password=eliu";

        private bool query_status;
        private int? count;
        private DataTable data_table;
        private static MySqlConnection connection;
        private MySqlDataReader data_reader;
        private MySqlCommand command;


        public bool TestConnection(DbContext context)
        {
            DbConnection conn = context.Database.GetDbConnection();
            try
            {
                conn.Open();   // Check the database connection
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreateDatabase(DbContext context)
        {
            try
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public void DropTable(string TableName)
        {
            using var con = new MySqlConnection(_conn);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DROP TABLE IF EXISTS " + TableName;
            cmd.ExecuteNonQuery();
        }

        public void AddRowToTests(Emerald1Context context, string testName, string elapsed, bool testResult)
        {
            // Given a list of column names and values, and a table name, add the data to the DB
            //string column1 = "Date";
            //string column2 = "Time";
            //string column3 = "Test Name";
            //string column4 = "Test Run Time";
            //string column5 = "Result";

            string result = "";
            if (testResult == true)
            {
                result = "Passed";
            }
            else
            {
                result = "Failed";
            }

            string dataDate = DateTime.Now.ToString("dd/MM/yyyy");
            string dataTime = DateTime.Now.ToString("HH:mm:ss");
            string dataName = testName;
            string dataTimeTaken = elapsed;
            string dataResult = result;

            using (context)
            {
                GroupApi.Test testData = new GroupApi.Test();
                testData.DateofTest = dataDate;
                testData.TimeOfTest = dataTime;
                testData.NameOfTest = dataName;
                testData.TimeTaken = dataTimeTaken;
                testData.TestResult = dataResult;

                context.TestLog.Add(testData);
                context.SaveChanges();
            }
        }

        public void AddNoTimeRowToTests(Emerald1Context context, string testName, TimeSpan elapsed, bool testResult)
        {
            // Given a list of column names and values, and a table name, add the data to the DB
            //string column1 = "Date";
            //string column2 = "Time";
            //string column3 = "Test Name";
            //string column4 = "Test Run Time";
            //string column5 = "Result";

            string result = "";
            if (testResult == true)
            {
                result = "Passed";
            }
            else
            {
                result = "Failed";
            }

            string dataDate = DateTime.Now.ToString("dd/MM/yyyy");
            string dataTime = DateTime.Now.ToString("HH:mm:ss");
            string dataName = testName;
            string dataTimeTaken = elapsed.ToString();
            string dataResult = result;

            using (context)
            {
                GroupApi.Test testData = new GroupApi.Test();
                testData.DateofTest = dataDate;
                testData.TimeOfTest = dataTime;
                testData.NameOfTest = dataName;
                testData.TimeTaken = dataTimeTaken;
                testData.TestResult = dataResult;

                context.TestLog.Add(testData);
                context.SaveChanges();
            }
        }

        public double ReturnAvgTime(Emerald1Context context, int N, string searchTerm)
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

            List<GroupApi.Test> excludeLast = new List<GroupApi.Test>();
            // Using 10 items, get the avg
            if (listOfResults.Count > (N+1))
            {
                 excludeLast = listOfResults.GetRange((listOfResults.Count() - 1 - N), N);
            }
            else // if less than N items, remove last result
            {
                 excludeLast = listOfResults.GetRange(0, listOfResults.Count()-1);
            }

            List<double> timesToAvg = new List<double>();
            foreach (var row in excludeLast)
            {
                var time = row.TimeTaken;
                TimeSpan timeConverted = TimeSpan.Parse(time);
                var timeTest = timeConverted.TotalSeconds;
                timesToAvg.Add(timeTest);
            }
            var avgTime = timesToAvg.Average();
            return avgTime;
        }


        public double ReturnLastTime(Emerald1Context context, string searchTerm)
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

            var lastResult = listOfResults.Last();
            var timeLastResult = lastResult.TimeTaken;
            TimeSpan timeConverted = TimeSpan.Parse(timeLastResult);
            var timeTest = timeConverted.TotalSeconds;
            return timeTest;
        }
    }
}

