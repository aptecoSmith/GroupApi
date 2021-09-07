using EFCore1;
using EFCore1.DBContext;
using System;

namespace ApiMethods1
{
    internal class Program
    {
        private static SmithOrbitApiMethods _oam = new SmithOrbitApiMethods();
        private static string _apiUrl = "https://cloudtest.faststats.co.uk/Test/OrbitAPI/";


        private static GroupApi.EmeraldRestAPIMethods _EmeraldApi = new GroupApi.EmeraldRestAPIMethods(_apiUrl);

        private static void Main(string[] args)
        {
            Console.WriteLine("ApiMethods");
            _EmeraldApi.CheckIfTempFolder();
            _EmeraldApi.GetAuthToken();
            var abc = _EmeraldApi._authToken;

            DBHelper _dbh = new DBHelper();

            Console.WriteLine(_dbh._conn);

            var context = new Emerald1Context();

            _dbh.TestConnection(context);
            _dbh.CreateDatabase(context);
            _dbh.ReturnAvgTime(context, 10, "GetDash");


           // _dbh.selectRow(context);
            #region John's Stuff
            //_oam._ac.GetAuthToken(_oam._username, _oam._password);
            //var olddash = _oam.GetDashboardDefinition();
            //_oam.SaveDashboardDefinition(olddash);

            //var jsonFromFile = _oam.LoadDashFromFile();
            //var loadedDashObj = _oam.ConvertDashJsonToObject(jsonFromFile);
            //var newdash = _oam.NewTitleDashboardDefinition(loadedDashObj, $"{DateTime.Now.ToString()} Smith API dashboard");
            ////no need to reserialise as AddJsonBody will take an object
            //var success = _oam.CreateDashFromDefinition(newdash);
            #endregion John's Stuff

            #region Emeralds Audience Calling
            //string audienceChosenId = "3";
            //_EmeraldApi.GetAuthToken();
            //_EmeraldApi.CheckIfTempFolder();
            //_EmeraldApi.GetAudiences();
            //_EmeraldApi.PickAudience(_EmeraldApi.audienceListResponse, audienceChosenId);
            //_EmeraldApi.GetAudienceDefinition(audienceChosenId);

            #endregion Emeralds Audience Calling
            #region timing please

            //start a timer
            //end a timer

            //record the results - write them to file

            #endregion timing please
        }

    }
}