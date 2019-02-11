using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerApp.Models
{
   public class PhoneRec
    {
        [Key]
        public int PhoneId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }



        public ICollection<AddInfo> PhoneColl { get; set; }
        public ICollection<MessageRec> PhoneMesColl { get; set; }

        public PhoneRec()
        {
            PhoneColl = new List<AddInfo>();
            PhoneMesColl = new List<MessageRec>();
        }
    }
}
