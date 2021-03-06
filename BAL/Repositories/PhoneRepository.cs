﻿using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCustomerApp.Data;
using WebCustomerApp.Models;

namespace BAL.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ApplicationDbContext sendingDbContext) : base(sendingDbContext)
        { }

        public List<Phone> GetByUserId(string userId)
        {
            return _dbSet.Where(item => item.UserId == userId).ToList();
        }
    }
}
