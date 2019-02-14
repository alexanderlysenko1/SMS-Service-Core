using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Interface
{
    public interface IPhoneRepository  : IRepository<Phone>
    {
        List<Phone> GetByUserId(string senderId);
    }
}
