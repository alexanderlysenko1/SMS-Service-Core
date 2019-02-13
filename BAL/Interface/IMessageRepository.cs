using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Interface
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> GetMessagesBySenderId(string senderId);
    }
}
