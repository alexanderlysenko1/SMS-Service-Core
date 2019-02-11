using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerApp.Models
{
   public class AddInfo
    {
        [Key]
        public int AdInfoId { get; set; }

        public int? PhonesId { get; set; }
        [ForeignKey("PhonesId")]
        public PhoneRec PhoneRec { get; set; }

        public string AddfInfo { get; set; }

    }
}
