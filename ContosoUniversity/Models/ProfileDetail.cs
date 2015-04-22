using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    //ProfileMeta is Principal Class
    //ProfileDetail is Dependent Class
    public class ProfileDetail
    {
        
        //classNameID or ID is interpreted by EF as PK.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //ForeignKey("<Navigation Property Name>")
        [Key, ForeignKey("ProfileMeta")] 
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int ProfileMetaID {get; set;}
        public string UserName { get; set; }
        public string Age { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
      
        //Optional Details
        public string HighSchool { get; set; }
        public string UndergraduateSchool { get; set; }
        public string GraduateSchool { get; set; }

        public virtual ProfileMeta ProfileMeta { get; set; }
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
        
    }
 
}