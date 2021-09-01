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
            //_oam._ac.GetAuthToken(_oam._username, _oam._password);
            //var olddash = _oam.GetDashboardDefinition();
            //_oam.SaveDashboardDefinition(olddash);

            //var jsonFromFile = _oam.LoadDashFromFile();
            //var loadedDashObj = _oam.ConvertDashJsonToObject(jsonFromFile);
            //var newdash = _oam.NewTitleDashboardDefinition(loadedDashObj, $"{DateTime.Now.ToString()} Smith API dashboard");
            ////no need to reserialise as AddJsonBody will take an object
            //var success = _oam.CreateDashFromDefinition(newdash);

            _EmeraldApi.GetAuthToken();
            _EmeraldApi.CheckIfTempFolder();
            _EmeraldApi.GetAudiences();

            #region timing please

            //start a timer
            _EmeraldApi.GetAuthToken();
            var abc = _EmeraldApi._authToken;
            //end a timer

            //record the results - write them to file

            #endregion timing please
        }
    }
}