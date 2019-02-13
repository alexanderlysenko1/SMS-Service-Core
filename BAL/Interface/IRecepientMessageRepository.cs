using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Interface
{
   public interface IRecepientMessageRepository : IRepository<RecepientMessage>
    {
        List<RecepientMessage> GetRecepientsMessagesByMessageId(int messageId);
        List<RecepientMessage> GetRecepientsMessagesByRecipientId(int messageId);
    }
}
