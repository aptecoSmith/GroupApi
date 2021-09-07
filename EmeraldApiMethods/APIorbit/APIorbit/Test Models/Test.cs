using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupApi
{
    public class Test
    {
        [Key]
        public int Key { get; set; }
        public string NameOfTest { get; set; }
        public string DateofTest { get; set; }
        public string TimeOfTest { get; set; }
        public string TimeTaken { get; set; }
        public string TestResult { get; set; }

    }
}
