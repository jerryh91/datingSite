using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class ProfileDetail
    { 
        //classNameID or ID is interpreted by EF as PK.
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Age { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
      
        //Optional Details
        public string HighSchool { get; set; }
        public string UndergraduateSchool { get; set; }
        public string GraduateSchool { get; set; }

        //public Dictionary<string, string> OptionalDetails { get; set; }
        //public ProfileDetail()
        //{
        //    OptionalDetails = new Dictionary<string, string>()
        //    {

        //        {"HighSchool", ""},
        //        {"UndergraduateSchool", ""},
        //        {"GraduateSchool", ""},

        //    };
        //}
        public virtual ProfileMeta ProfileMeta { get; set; }
    }
 
}