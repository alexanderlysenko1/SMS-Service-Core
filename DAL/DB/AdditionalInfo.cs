using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerApp.Models
{
   public class AdditionalInfo
    {
        [Key]
        public int AdditionalInfoId { get; set; }
        public int PhoneId { get; set; }
        public string AdditionalInfos { get; set; }

        [ForeignKey("PhoneId")]
        public Phone Phone { get; set; }

    }
}
