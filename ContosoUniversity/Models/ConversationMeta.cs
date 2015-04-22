using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class ConversationMeta
    {
        public int ID {get; set;}

        //Dynamic Array: All messages for a given conversation/msg thread
        //[NotMapped]
        //public string MessageDetailsID {get; set;}
        public int InitiatorID { get; set; }
        public int ResponderID { get; set; }

        public virtual ICollection<MessageDetail> MessageDetails { get; set; }
        public virtual ICollection<ProfileMeta> ProfileMetas { get; set; }
    }
}