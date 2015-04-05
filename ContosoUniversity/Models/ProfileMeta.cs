using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class ProfileMeta
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string password { get; set; }

        //Dynamic Array
        public ArrayList ConversationMetaID { get; set; } 
        public int ProfileDetailID { get; set; }

        public virtual ProfileDetail ProfileDetail {get; set;}
        public virtual ICollection<MessageDetail> MessageDetails { get; set; }
        public virtual ICollection<ConversationMeta> ConversationMetas { get; set; }
    }
}