using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerApp.Models;

namespace WebCustomerApp.Models
{
    public class RecepientMessage
    {
        [Key]
        public int RecepientMessageId { get; set; }
        public int MessageId { get; set; }
        public int PhoneId { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        public DateTime DateTimeOfStartOfSending { get; set; }
        public DateTime DateTimeOfEndOfSending { get; set; }
        public int CountOfSending { get; set; }


        [ForeignKey("PhoneId")]
        public Phone Recepient { get; set; }
        [ForeignKey("MessageId")]
        public Message Message { get; set; }
    }
}
