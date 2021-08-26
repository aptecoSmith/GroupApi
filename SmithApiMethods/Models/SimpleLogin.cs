using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMethods1.Models
{
    public class SimpleLogin
    {
        public class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class Bundle
        {
            public int id { get; set; }
            public string name { get; set; }
            public string instanceName { get; set; }
        }

        public class Licence
        {
            public bool audienceSelection { get; set; }
            public bool audiencePreview { get; set; }
            public bool export { get; set; }
            public bool advancedQuery { get; set; }
            public bool cube { get; set; }
            public bool profile { get; set; }
            public bool dashboards { get; set; }
            public bool dashboardsPareto { get; set; }
            public bool campaignSingleStep { get; set; }
            public bool campaignOrbitOverview { get; set; }
            public List<Bundle> bundles { get; set; }
        }

        public class Root
        {
            public string accessToken { get; set; }
            public User user { get; set; }
            public string sessionId { get; set; }
            public DateTime lastLogin { get; set; }
            public Licence licence { get; set; }
        }
    }
}