using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Data;
using WebCustomerApp.Models;

namespace BAL.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ApplicationDbContext sendingDbContext) : base(sendingDbContext)
        { }
    }
}
