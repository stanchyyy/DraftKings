using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Book_lib.Models
{
    public class UserDeleteModel
    {
        public string EmailAddress { get; set; }

        public UserDeleteModel(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public override string ToString() => JsonSerializer.Serialize<UserDeleteModel>(this);
    }
}
