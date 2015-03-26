using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Message
    {

        public int ID { get; set; }
        public int ProfileID {get; set;}
        public string MessageContent { get; set; }

        //Message : Profile Association
        //1 Message is sent by only 1 Profile
        public virtual Profile Profile { get; set; }
    }
}