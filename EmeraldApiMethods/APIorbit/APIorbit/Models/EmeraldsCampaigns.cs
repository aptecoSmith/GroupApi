using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models
{
    public class EmeraldsCampaigns
    { 
        public class Path
        {
            public string id { get; set; }
            public string description { get; set; }
        }

        public class List
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

        public class Root
        {
            public int offset { get; set; }
            public int count { get; set; }
            public int totalCount { get; set; }
            public List<List> list { get; set; }
        }


    }
}
