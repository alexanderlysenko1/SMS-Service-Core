using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerApp.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }

        public ICollection<RecepientMessage> RecepientMessages { get; set; }
        public ICollection<AdditionalInfo> AdditionalInfos { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public Phone()
        {
            RecepientMessages = new List<RecepientMessage>();
            AdditionalInfos = new List<AdditionalInfo>();
        }
    }
}
