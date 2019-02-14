using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.MessageViewModels
{
    public class MessageModel
    {
        [Required]
        public string TextOfMessage { get; set; }
        public List<string> Recepients { get; set; }
    }
}
