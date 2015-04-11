using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class ProfileMeta
    {
        [Key, ForeignKey("ProfileDetail")]
        public int ID { get; set; }
        public string Username { get; set; }
        public string password { get; set; }

        //Dynamic Array
        [NotMapped]
        public ArrayList ConversationMetaID { get; set; } 
        public int ProfileDetailID { get; set; }

        public virtual ProfileDetail ProfileDetail {get; set;}
        public virtual ICollection<MessageDetail> MessageDetails { get; set; }
        public virtual ICollection<ConversationMeta> ConversationMetas { get; set; }
    }
}