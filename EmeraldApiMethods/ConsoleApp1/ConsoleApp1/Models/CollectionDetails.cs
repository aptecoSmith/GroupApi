using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models
{
    public class CollectionDetails
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

        public class Root
        {
            public int id { get; set; }
            public Owner owner { get; set; }
            public int numberOfParts { get; set; }
            public int numberOfUsersSharedWith { get; set; }
            public bool sharedToAll { get; set; }
            public int shareId { get; set; }
            public int numberOfHits { get; set; }
            public string systemName { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public DateTime? creationDate { get; set; }
            public string filePath { get; set; }
            public DateTime? deletionDate { get; set; }
        }


    }
}
