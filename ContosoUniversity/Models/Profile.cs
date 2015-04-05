using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Profile
    { 
        //classNameID or ID is interpreted by EF as PK.
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Age { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public Dictionary<string, string> ProfileDetails { get; set; }

        public Profile()
        {
            ProfileDetails = new Dictionary<string, string>()
            {
                {"CurrentCity", ""},
                {"HighSchool", ""},
                {"UndergraduateSchool", ""},
                {"GraduateSchool", ""},

            };
        }

        //Profile : Message Association
        //1 Profile Can send *(Multiple) Messages
        public virtual ICollection<Message> Messages { get; set; }

    }
 
}