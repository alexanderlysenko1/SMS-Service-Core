using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebCustomerApp.Models
{
    [DataContract]
    [Serializable]
    public class Message
    {
        [Key]
        [DataMember]
        public int MessageId { get; set; }
        [DataMember]
        public string SenderId { get; set; }
        [DataMember]
        public string TextOfMessage { get; set; }

        [ForeignKey("SenderId")]
        [XmlIgnore]
        public ApplicationUser Sender { get; set; }
        [XmlIgnore]
        public ICollection<RecepientMessage> RecepientMessages { get; set; }

        public Message()
        {
            RecepientMessages = new List<RecepientMessage>();
        }
    }
}
