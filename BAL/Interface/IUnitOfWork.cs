using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Interface
{
   public interface IUnitOfWork
    {
        UserManager<ApplicationUser> _userManager { get; }
        IMessageRepository _messageRepository { get; }
        IRecepientMessageRepository _recepientMessageRepository { get; }
        IPhoneRepository _phoneRepository { get; }
    

        void SaveChanges();
    }
}
