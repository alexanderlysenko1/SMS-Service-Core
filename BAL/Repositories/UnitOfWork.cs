using BAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserManager<ApplicationUser> _userManager { get; }
        public IMessageRepository _messageRepository { get; }
        public IRecepientMessageRepository _recepientMessageRepository { get; }
        public IPhoneRepository _phoneRepository { get; }
        public IAdditionalInfoRepository _additionalInfoRepository { get; }


        public UnitOfWork(UserManager<ApplicationUser> userManager, IMessageRepository messageRepository, IRecepientMessageRepository recepientMessageRepository,
            IPhoneRepository phoneRepository, IAdditionalInfoRepository additionalInfoRepository)
        {
            _userManager = userManager;
            _messageRepository = messageRepository;
            _recepientMessageRepository = recepientMessageRepository;
            _phoneRepository = phoneRepository;
            _additionalInfoRepository = additionalInfoRepository;
        }

        public void SaveChanges()
        {
            _messageRepository.SaveChanges();
            _recepientMessageRepository.SaveChanges();
           // _phoneRepository.SaveChanges();
            _additionalInfoRepository.SaveChanges();
        }
    }
}
