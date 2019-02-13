using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;

namespace BAL.Interface
{
    public interface IAdditionalInfoRepository : IRepository<AdditionalInfo>
    {
        List<AdditionalInfo> GetByPhoneId(int phoneId);
    }
}
