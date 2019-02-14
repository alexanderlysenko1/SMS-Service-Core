using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace Model.MessageViewModels
{
  public class ModelForMessageForSendingToUI 
    {
        public Message Message;
        public List<Phone> Phones;

        public ModelForMessageForSendingToUI(Message message, List<Phone> phones)
        {
            Message = message;
            Phones = phones;

        }

    }

}
