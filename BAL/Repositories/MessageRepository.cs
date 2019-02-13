using BAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Data;
using WebCustomerApp.Models;
using System.Linq;

namespace BAL.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }

        public List<Message> GetMessagesBySenderId(string senderId)
        {
            return _dbSet.Where(item => item.SenderId == senderId).ToList();
        }
    }
}
