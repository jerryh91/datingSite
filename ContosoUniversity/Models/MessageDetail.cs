using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class MessageDetail
    {

        public int ID { get; set; }

        public int SenderID {get; set;}
        public int ReceiverID { get; set; }

        public string MessageContent { get; set; }

   
        public virtual ICollection <ProfileMeta> ProfileMetas { get; set; }
        public virtual ConversationMeta ConversationMeta { get; set; }
    }
}