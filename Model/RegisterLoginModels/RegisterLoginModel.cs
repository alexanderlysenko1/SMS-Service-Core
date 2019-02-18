using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models.AccountViewModels;

namespace WebCustomerApp.Models.RegisterLoginModels
{
   public class RegisterLoginModel
    {
        public RegisterViewModel RegisterModel { get; set; }
        public LoginViewModel LoginModel { get; set; }
    }
}
