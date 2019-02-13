using BAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCustomerApp.Data;
using WebCustomerApp.Models;


namespace BAL.Repositories
{
    public class AdditionalInfoRepository : Repository<AdditionalInfo>, IAdditionalInfoRepository
    {
        public AdditionalInfoRepository(ApplicationDbContext sendingDbContext) : base(sendingDbContext)
        { }

        public List<AdditionalInfo> GetByPhoneId(int phoneId)
        {
            return _dbSet.Where(item => item.PhoneId == phoneId).ToList();
        }
    }
}
