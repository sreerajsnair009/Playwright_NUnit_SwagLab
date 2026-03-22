using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlaywrightDemo1.DataModels
{
    public class LoginUser
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string LoginError { get; set; } = "";
    }
}
