using System;

namespace ApiMethods1
{
    internal class Program
    {
        private static OrbitApiMethods _oam = new OrbitApiMethods();

        private static void Main(string[] args)
        {
            Console.WriteLine("ApiMethods");
            _oam._ac.GetAuthToken(_oam._username, _oam._password);
            var olddash = _oam.GetDashboardDefinition();
            _oam.SaveDashboardDefinition(olddash);

            var jsonFromFile = _oam.LoadDashFromFile();
            var loadedDashObj = _oam.ConvertDashJsonToObject(jsonFromFile);
            var newdash = _oam.NewTitleDashboardDefinition(loadedDashObj, $"{DateTime.Now.ToString()} Smith API dashboard");
            //no need to reserialise as AddJsonBody will take an object
            var success = _oam.CreateDashFromDefinition(newdash);
        }
    }
}