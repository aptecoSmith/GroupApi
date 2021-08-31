using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models
{
    public class Dashboards
    {
        public class Owner
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class LastUpdatedBy
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class List
        {
            public string viewingUsername { get; set; }
            public string status { get; set; }
            public bool sharedToMe { get; set; }
            public bool sharedByMe { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string systemName { get; set; }
            public DateTime createdOn { get; set; }
            public Owner owner { get; set; }
            public DateTime lastUpdatedOn { get; set; }
            public LastUpdatedBy lastUpdatedBy { get; set; }
            public int lastUpdateId { get; set; }
            public int numberOfUsersSharedWith { get; set; }
            public bool sharedToAll { get; set; }
            public int shareId { get; set; }
            public int numberOfHits { get; set; }
            public DateTime deletedOn { get; set; }
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
