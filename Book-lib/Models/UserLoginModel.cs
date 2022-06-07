using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_lib.Models
{
    public class UserLoginModel
    {
        public string EmailAddress { get; set; }
        private string Password { get; set; }

        public UserLoginModel(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public override string ToString() => JsonSerializer.Serialize<UserLoginModel>(this);
    }
}
