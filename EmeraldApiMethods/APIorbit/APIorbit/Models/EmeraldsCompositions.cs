using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models
{
    public class EmeraldsCompositions
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Owner
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class List
        {
            public int id { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string systemName { get; set; }
            public Owner owner { get; set; }
            public int numberOfUsersSharedWith { get; set; }
            public bool sharedToAll { get; set; }
            public int shareId { get; set; }
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
