using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models.Collections
{
    public class CreateCollection
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Root
        {
            public string title { get; set; }
            public string description { get; set; }
            public DateTime? creationDate { get; set; }
            public string filePath { get; set; }
            public DateTime? deletionDate { get; set; }
        }


    }
}
