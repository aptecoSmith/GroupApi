using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models
{
    public class CampaignDetails
    {
        public class Path
        {
            public string id { get; set; }
            public string description { get; set; }
        }

        public class Root
        {
            public string id { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public int schemaId { get; set; }
            public string schemaIdType { get; set; }
            public string parentId { get; set; }
            public string parentType { get; set; }
            public List<Path> path { get; set; }
        }
    }
}
