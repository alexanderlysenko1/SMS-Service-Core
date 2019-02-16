using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.PhoneViewModels
{
   public class RecepientModel
    {
        public int id { get; set; }
        [Required]
        [RegularExpression(@"^\+[0-9]{12}$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
    }
}
