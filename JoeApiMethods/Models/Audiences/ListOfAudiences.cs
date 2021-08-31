using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models.Audiences
{
    class ListOfAudiences
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

        public class LastUpdatedUser
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class Dependency
        {
            public int dependentId { get; set; }
            public string dependentType { get; set; }
        }

        public class List
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public DateTime? creationDate { get; set; }
            public Owner owner { get; set; }
            public DateTime? deletionDate { get; set; }
            public string resolveTableName { get; set; }
            public int resolveTableNettCount { get; set; }
            public DateTime? lastCountDate { get; set; }
            public int numberOfUsersSharedWith { get; set; }
            public bool sharedToAll { get; set; }
            public int shareId { get; set; }
            public int numberOfHits { get; set; }
            public string systemName { get; set; }
            public LastUpdatedUser lastUpdatedUser { get; set; }
            public DateTime? lastUpdatedDate { get; set; }
            public int lastUpdateId { get; set; }
            public string campaignId { get; set; }
            public List<Dependency> dependencies { get; set; }
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
